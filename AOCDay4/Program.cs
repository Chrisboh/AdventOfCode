
string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AOCDay4\input.txt");
int TotalSubsets = 0;
int TotalIntersect = 0;

foreach (string line in lines)
{
    Tuple<List<int>, List<int>> data = ParseLine(line);
    
    // Puzzle 1
    if( !data.Item1.Except(data.Item2).Any() || !data.Item2.Except(data.Item1).Any() )
        TotalSubsets++;

    // Puzzle 2
    if( data.Item1.Intersect(data.Item2).Any() )
        TotalIntersect++;
}

Console.WriteLine(TotalSubsets);
Console.WriteLine(TotalIntersect);  

Tuple<List<int>, List<int>> ParseLine(string line)
{
    string[] parts = line.Split(",");
    string[] range1 = parts[0].Split("-");
    string[] range2 = parts[1].Split("-");

    List<int> arr1 = GenerateArr(int.Parse(range1[0]), int.Parse(range1[1]));
    List<int> arr2 = GenerateArr(int.Parse(range2[0]), int.Parse(range2[1]));

    return new Tuple<List<int>, List<int>>(arr1, arr2);
}

List<int> GenerateArr(int v1, int v2)
{
    List<int> arr = new List<int>();
    for (int ii = v1; ii <= v2; ii++)
    {
        arr.Add(ii);
    }

    return arr;
}