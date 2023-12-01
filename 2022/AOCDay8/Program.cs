using System.Data;

string[] lines = System.IO.File.ReadAllLines(@"c:\src\AOC\AOCDay8\input.txt");
int[,] data = new int[lines.Length, lines[0].Length];

for (int ii = 0; ii < lines.Length; ii++)
{
	for(int jj  = 0; jj < lines[ii].Length; jj++)
	{
		data[ii, jj] = int.Parse(lines[ii][jj].ToString());
	}
}

int bestDist = 0;
for (int ii = 0; ii < data.GetLength(0); ii++)
{
	for (int jj = 0; jj < data.GetLength(1); jj++)
	{
		int distValue = VisibleLeft(data, ii, jj) * VisibleRight(data, ii, jj) * VisibleUp(data, ii, jj) * VisibleDown(data, ii, jj);

		if (distValue > bestDist)
			bestDist = distValue;
	}
}

int VisibleDown(int[,] data, int ii, int jj)
{
	int count = 0;
	for (int qq = ii + 1; qq < data.GetLength(0); qq++)
	{
		count++;
		if (data[ii, jj] <= data[qq, jj])
			break;
	}

	return count;
}

int VisibleUp(int[,] data, int ii, int jj)
{
	int count = 0;
	for (int qq = ii - 1; qq >= 0; qq--)
	{
		count++;
		if (data[ii, jj] <= data[qq, jj])
			break;
	}

	return count;
}

int VisibleRight(int[,] data, int ii, int jj)
{
	int count = 0;
	for (int qq = jj + 1; qq < data.GetLength(1); qq++)
	{
		count++;
		if (data[ii, jj] <= data[ii, qq])
			break;
	}

	return count;
}

int VisibleLeft(int[,] data, int ii, int jj)
{
	int count = 0;
	for (int qq = jj - 1; qq >= 0; qq--)
	{
		count++;
		if (data[ii, jj] <= data[ii, qq])
			break;
	}

	return count;
}

Console.WriteLine(bestDist);