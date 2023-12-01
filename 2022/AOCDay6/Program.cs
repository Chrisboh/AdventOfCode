string[] lines = System.IO.File.ReadAllLines(@"c:\src\AOC\AOCDay6\input.txt");

for (int ii = 0; ii < lines[0].Length; ii++)
{
    string marker = lines[0].Substring(ii, 14);

    if( marker.ToCharArray().Distinct().Count() == 14 )
    {
        Console.WriteLine(ii + 14);
        break;
    }
}