
using System.Text.RegularExpressions;

string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AOCDay5\input.txt");

List<Stack<char>> stack = new List<Stack<char>>();

// Build base stack
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());
stack.Add(new Stack<char>());

stack[0].Push('B');
stack[0].Push('P');
stack[0].Push('N');
stack[0].Push('Q');
stack[0].Push('H');
stack[0].Push('D');
stack[0].Push('R');
stack[0].Push('T');

stack[1].Push('W');
stack[1].Push('G');
stack[1].Push('B');
stack[1].Push('J');
stack[1].Push('T');
stack[1].Push('V');

stack[2].Push('N');
stack[2].Push('R');
stack[2].Push('H');
stack[2].Push('D');
stack[2].Push('S');
stack[2].Push('V');
stack[2].Push('M');
stack[2].Push('Q');

stack[3].Push('P');
stack[3].Push('Z');
stack[3].Push('N');
stack[3].Push('M');
stack[3].Push('C');

stack[4].Push('D');
stack[4].Push('Z');
stack[4].Push('B');

stack[5].Push('V');
stack[5].Push('C');
stack[5].Push('W');
stack[5].Push('Z');

stack[6].Push('G');
stack[6].Push('Z');
stack[6].Push('N');
stack[6].Push('C');
stack[6].Push('V');
stack[6].Push('Q');
stack[6].Push('L');
stack[6].Push('S');

stack[7].Push('L');
stack[7].Push('G');
stack[7].Push('J');
stack[7].Push('M');
stack[7].Push('D');
stack[7].Push('N');
stack[7].Push('V');

stack[8].Push('T');
stack[8].Push('P');
stack[8].Push('M');
stack[8].Push('F');
stack[8].Push('Z');
stack[8].Push('C');
stack[8].Push('G');

foreach (string line in lines)
{
    Regex rx = new Regex(@"move (\d+) from (\d) to (\d)");
    MatchCollection matches = rx.Matches(line);
    int numToMove = int.Parse(matches[0].Groups[1].Value);
    int startingStack = int.Parse(matches[0].Groups[2].Value) - 1;
    int destStack = int.Parse(matches[0].Groups[3].Value) - 1;

    Stack<char> tmpStack = new Stack<char>();
    for (int ii = 0; ii < numToMove; ii++)
    {
        tmpStack.Push(stack[startingStack].Pop());
    }

    for (int i = 0; i < numToMove; i++)
    {
        stack[destStack].Push(tmpStack.Pop());
    }
}

for (int ii = 0; ii < stack.Count; ii++)
{
    Console.WriteLine(stack[ii].Pop().ToString());
}