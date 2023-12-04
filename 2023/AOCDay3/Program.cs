using System.Text;

namespace AOCDay3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AdventOfCode\2023\AOCDay3\input.txt");
            //int sumOfPartNumbers = 0;
            long gearRatios = 0;
            Dictionary<int, List<NumberData>> numberData = new Dictionary<int, List<NumberData>>();

            for (int qq = 0; qq < lines.Length; qq++)
            {
                string line = lines[qq];
                for (int i = 0; i < line.Length; i++)
                {
                    // This is the solution to Part 1
                    //if (char.IsDigit(line[i]))
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    for(int j = i; j < line.Length && char.IsDigit(line[j]); j++)
                    //    {
                    //        sb.Append(line[j]);
                    //    }

                    //    if(IsSchematicPart(sb.ToString(), i, qq, lines))
                    //    {
                    //        Console.WriteLine($"PartNumber: {sb.ToString()} is valid");
                    //        sumOfPartNumbers += int.Parse(sb.ToString());
                    //    }

                    //    i += sb.Length;
                    //}

                    if (char.IsDigit(line[i]))
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int j = i; j < line.Length && char.IsDigit(line[j]); j++)
                        {
                            sb.Append(line[j]);
                        }

                        if(!numberData.ContainsKey(qq))
                            numberData.Add(qq, new List<NumberData>());

                        numberData[qq].Add(new NumberData(int.Parse(sb.ToString()), qq, i, i + sb.Length - 1));

                        i += sb.Length;
                    }
                }
            }

            for (int qq = 0;qq < lines.Length; qq++)
            {
                string line = lines[qq];
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '*')
                    {
                        gearRatios += IsGear(numberData, lines, qq, i);
                    }
                }
            }

            Console.WriteLine(gearRatios.ToString());
            //Console.WriteLine(sumOfPartNumbers);
        }

        private static long IsGear(Dictionary<int, List<NumberData>> numberData, string[] lines, int lineNumber, int startingPos)
        {
            int totalSpaceToCheck = startingPos == 0 || startingPos + 1 == lines[lineNumber].Length ? 2 : 3;
            int checkStartPos = startingPos > 0 ? startingPos - 1 : startingPos;
            int numSpacesToCheck = startingPos + totalSpaceToCheck == lines[lineNumber].Length ? totalSpaceToCheck - 1 : totalSpaceToCheck;
            List<NumberData> gears = new List<NumberData>();

            // Check Above
            if (lineNumber != 0)
            {
                if (numberData.ContainsKey(lineNumber - 1))
                {
                    foreach (NumberData num in numberData[lineNumber - 1])
                    {
                        if (num.IsInRange(lineNumber - 1, checkStartPos, checkStartPos + numSpacesToCheck - 1))
                            gears.Add(num);
                    }
                }
            }

            // Check Left
            if (startingPos > 0)
            {
                if (numberData.ContainsKey(lineNumber))
                {
                    foreach (NumberData num in numberData[lineNumber])
                    {
                        if (num.IsInRange(lineNumber, checkStartPos, checkStartPos))
                            gears.Add(num);
                    }
                }
            }

            // Check Right
            if (startingPos + 1 != lines[lineNumber].Length)
            {
                if (numberData.ContainsKey(lineNumber))
                {
                    foreach (NumberData num in numberData[lineNumber])
                    {
                        if (num.IsInRange(lineNumber, startingPos + 1, startingPos + 1))
                            gears.Add(num);
                    }
                }
            }

            // Check Below
            if (lineNumber != lines.Length - 1)
            {
                if (numberData.ContainsKey(lineNumber + 1))
                {
                    foreach (NumberData num in numberData[lineNumber + 1])
                    {
                        if (num.IsInRange(lineNumber + 1, checkStartPos, checkStartPos + numSpacesToCheck - 1))
                            gears.Add(num);
                    }
                }
            }

            if (gears.Count == 2)
            {
                Console.WriteLine($"Gear 1: {gears[0].Value.ToString()} Gear 2: {gears[1].Value.ToString()}");
                return gears[0].Value * gears[1].Value;
            }

            return 0;
        }

        private static bool IsSchematicPart(string partNum, int startingPos, int lineNumber, string[] lines)
        {
            bool isPart = false;
            int totalSpaceToCheck = startingPos == 0 || startingPos + partNum.Length == lines[lineNumber].Length ? partNum.Length + 1 : partNum.Length +2;
            int checkStartPos = startingPos > 0 ? startingPos - 1 : startingPos;
            int numSpacesToCheck = startingPos + totalSpaceToCheck == lines[lineNumber].Length ? totalSpaceToCheck - 1 : totalSpaceToCheck;

            // Check Above
            if (lineNumber != 0)
            {
                string bits = lines[lineNumber - 1].Substring(checkStartPos, numSpacesToCheck);
                foreach(char c in bits)
                {
                    if (!char.IsDigit(c) && c != '.')
                        isPart = true;
                }
            }

            // Check Left
            if( startingPos > 0)
            {
                char leftChar = lines[lineNumber][startingPos - 1];
                if (!char.IsDigit(leftChar) && leftChar != '.')
                    isPart = true;
            }

            // Check Right
            if (startingPos + partNum.Length != lines[lineNumber].Length)
            {
                char rightChar = lines[lineNumber][startingPos + partNum.Length];
                if (!char.IsDigit(rightChar) && rightChar != '.')
                    isPart = true;
            }

            // Check Below
            if (lineNumber != lines.Length - 1)
            {
                string bits = lines[lineNumber + 1].Substring(checkStartPos, numSpacesToCheck);
                foreach (char c in bits)
                {
                    if (!char.IsDigit(c) && c != '.')
                        isPart = true;
                }
            }

            return isPart;
        }
    }
}
