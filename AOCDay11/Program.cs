using System.Numerics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Monkey> monkeys = ParseData();

        for (int ii = 0; ii < 10000; ii++)
        {
            if (ii % 1000 == 0 || ii == 20)
                PrintInspection(monkeys);

            for (int jj = 0; jj < monkeys.Count; jj++)
            {
                //Console.WriteLine($"Monkey {jj}:");
                foreach (BigInteger item in monkeys[jj].Items)
                {
                    monkeys[jj].NumberOfItemsInspected++;
                    BigInteger worryLevel = monkeys[jj].OpType switch
                    {
                        Operations.Add => item + monkeys[jj].OpValue,
                        Operations.Multiply => item * (monkeys[jj].OpValue == 100 ? item : monkeys[jj].OpValue),
                    };

                    //worryLevel /= 3;

                    if (worryLevel % (BigInteger)monkeys[jj].TestValue == 0)
                    {
                        monkeys[monkeys[jj].TestTrueMonkey].Items.Add(worryLevel);
                    }
                    else
                    {
                        monkeys[monkeys[jj].TestFalseMonkey].Items.Add(worryLevel);
                    }
                }

                monkeys[jj].Items.Clear();
            }

            //for (int qq = 0; qq < monkeys.Count(); qq++)
            //{
            //    Console.Write($"Monkey {qq}: ");
            //    monkeys[qq].PrintItems();
            //}
            //Console.WriteLine();
        }

        PrintInspection(monkeys);
    }

    private static void PrintInspection(List<Monkey> monkeys)
    {
        List<BigInteger> monkeyBusiness = new List<BigInteger>();
        for (int qq = 0; qq < monkeys.Count; qq++)
        {
            monkeyBusiness.Add((BigInteger)monkeys[qq].NumberOfItemsInspected);
            Console.WriteLine($"Monkey {qq} inspected items {monkeys[qq].NumberOfItemsInspected} times ");
        }

        monkeyBusiness.Sort((x, y) => y.CompareTo(x));
        Console.WriteLine(monkeyBusiness[0] * monkeyBusiness[1]);
    }

    public static List<Monkey> ParseData()
    {
        string[] lines = File.ReadAllLines(@"D:\src\AdventOfCode\AOCDay11\input.txt");
        List<Monkey> result = new List<Monkey>();
        for (int ii = 0; ii < lines.Length; ii += 7)
        {
            // Parse items
            List<BigInteger> items = new List<BigInteger>();
            string[] data = lines[ii + 1].Substring(18).Split(", ");
            foreach (string item in data)
            {
                items.Add(BigInteger.Parse(item));
            }

            // Parse operation
            Operations opType = Operations.Add;
            data = lines[ii + 2].Substring(23).Split(" ");
            if (data[0] == "*")
                opType = Operations.Multiply;

            int opValue = 100;// Special case value
            if (data[1] != "old")
                opValue = int.Parse(data[1]);

            // Parse test
            int testValue = int.Parse(lines[ii + 3].Substring(21));

            // Parse true
            int testTrueMonkey = int.Parse(lines[ii + 4].Substring(29));

            // Parse false
            int testFalseMonkey = int.Parse(lines[ii + 5].Substring(29));

            result.Add(new Monkey(items, opType, opValue, testValue, testTrueMonkey, testFalseMonkey));
        }

        return result;
    }
}

public class Monkey
{
    public List<BigInteger> Items { get; set; }
    public Operations OpType { get; set; }
    public int OpValue { get; set; }
    public int TestValue { get; set; }
    public int TestTrueMonkey { get; set; }
    public int TestFalseMonkey { get; set; }
    public int NumberOfItemsInspected { get; set; } = 0;

    public Monkey(List<BigInteger> items, Operations opType, int opValue, int testValue, int testTrueMonkey, int testFalseMonkey)
    {
        Items = items;
        OpType = opType;
        OpValue = opValue;
        TestValue = testValue;
        TestTrueMonkey = testTrueMonkey;
        TestFalseMonkey = testFalseMonkey;
    }

    public void PrintItems()
    {
        StringBuilder output = new StringBuilder();
        foreach (BigInteger item in Items)
        {
            output.Append($"{item} ");
        }

        Console.WriteLine(output.ToString());
    }
}

public enum Operations
{
    Add,
    Multiply
}