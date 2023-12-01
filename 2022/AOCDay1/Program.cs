string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AOCDay1\input.txt");
int currentTotal = 0;
List<int> elves = new List<int>();

foreach (string line in lines)
{
    if(string.IsNullOrEmpty(line))
    {
        elves.Add(currentTotal);        
        currentTotal = 0;
    } else
    {
        currentTotal += int.Parse(line);
    }    
}

elves.Sort((x, y) => y.CompareTo(x));
Console.WriteLine(elves[0]);
Console.WriteLine(elves.Take(3).Sum(x=>x));