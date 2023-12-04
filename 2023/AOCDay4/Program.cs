
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AOCDay4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AdventOfCode\2023\AOCDay4\input.txt");
            Dictionary<int, int> cardCounters = new Dictionary<int, int>();

            for (int i = 0; i < lines.Length; i++)
            {
                cardCounters.Add(i, 1);
            }

            for (int card = 0; card < lines.Length; card++)
            {
                string line = lines[card];
                for (int i = 0; i < cardCounters[card]; i++)
                {
                    string cardData = line.Substring(line.IndexOf(':') + 1);
                    string[] datasets = cardData.Split('|');
                    HashSet<int> winningNumbers = ParseNumberSet(datasets[0]);
                    int cardPoints = 0;

                    foreach (string number in datasets[1].Split(" "))
                    {
                        if (!string.IsNullOrEmpty(number) && winningNumbers.Contains(int.Parse(number)))
                        {
                            cardPoints++;
                        }
                    }

                    for(int j = 1; j <= cardPoints; j++)
                    {
                        cardCounters[card + j]++;
                    }
                }
            }

            int totalScratchcards = 0;
            for (int i = 0; i < cardCounters.Count(); i++)
            {
                totalScratchcards += cardCounters[i];
            }

            Console.WriteLine(totalScratchcards);
        }

        private static HashSet<int> ParseNumberSet(string data)
        {
            HashSet<int> result = new HashSet<int>();
            
            foreach(string number in data.Split(" "))
            {
                if(!string.IsNullOrEmpty(number))
                    result.Add(int.Parse(number));
            }

            return result;
        }
    }
}
