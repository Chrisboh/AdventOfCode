
using System.Text;

namespace AOCDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AdventOfCode\2023\AOCDay1\input.txt");
            int total = 0;

            foreach (string line in lines) 
            {
                int value = ParseOutInt(line);
                Console.WriteLine(value);
                total += value;
            }

            Console.WriteLine($"total={total}");
        }

        private static int ParseOutInt(string line)
        {
            StringBuilder sb = new StringBuilder();
            char? first = null;
            char? last = null;

            Dictionary<string, char> numbers = new Dictionary<string, char>
            {
                { "zero", '0' },
                { "one", '1' },
                { "two", '2' },
                { "three", '3' },
                { "four", '4' },
                { "five", '5' },
                { "six", '6' },
                { "seven", '7' },
                { "eight", '8' },
                { "nine", '9' }
            };

            for (int i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    if (first == null)
                        first = line[i];
                    else
                        last = line[i];
                    
                } 
                else
                {
                    foreach (string item in numbers.Keys)
                    {
                        if (item.Length <= line.Length - i)
                        {
                            string part = line.Substring(i, item.Length);
                            if (item == part)
                            {
                                if (first == null)
                                    first = numbers[item];
                                else
                                    last = numbers[item];
                            }
                        }
                    }
                }
            }

            if(last == null)
            {
                last = first;
            }

            sb.Append(first);
            sb.Append(last);
            return int.Parse(sb.ToString());
        }
    }
}
