
string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AOCDay3\input.txt");
int total = 0;

// Puzzle 1
foreach (string line in lines)
{
    string compartment1 = line.Substring(0, line.Length / 2);
    string compartment2 = line.Substring(line.Length / 2);

    var uni1 = compartment1.Distinct();
    var uni2 = compartment2.Distinct();
    var ans = uni1.Intersect(uni2).First();

    if (char.IsUpper(ans))
        total += ans - 38;
    else
        total += ans - 96;
}

Console.WriteLine(total);

// Puzzle 2
total = 0;
for (int ii = 0; ii < lines.Length; ii+= 3)
{
    var uni1 = lines[ii].Distinct();
    var uni2 = lines[ii+1].Distinct();
    var uni3 = lines[ii+2].Distinct();

    var firstIntersect = uni1.Intersect(uni2);
    var ans = firstIntersect.Intersect(uni3).First();

    if (char.IsUpper(ans))
        total += ans - 38;
    else
        total += ans - 96;
}

Console.WriteLine(total);