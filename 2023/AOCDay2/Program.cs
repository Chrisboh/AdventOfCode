
using System.Diagnostics.CodeAnalysis;

namespace AOCDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\src\AOC\AdventOfCode\2023\AOCDay2\input.txt");
            int? possibleIdTotal = 0;

            foreach (string line in lines)
            {
                possibleIdTotal += ParseData(line);
            }

            Console.WriteLine(possibleIdTotal);
        }

        private static int? ParseData(string line)
        {
            int colinPos = line.IndexOf(':');
            string gameId = line.Substring(5, colinPos - 5);
            string data = line.Substring(++colinPos);
            string[] sets = data.Split(';');
            Dictionary<string, int?> minPosCubes = new Dictionary<string, int?>();
            int? totalPower = 1;
            
            foreach (string set in sets)
            {
                string[] cubes = set.Split(",");
                foreach (string cube in cubes)
                {
                    string cu = cube.TrimStart();
                    string[] cubeData = cu.Split(" ");
                    int numOfCubes = int.Parse(cubeData[0]);
                    minPosCubes[cubeData[1]] = FindHighestCubeValue(minPosCubes.ContainsKey(cubeData[1]) ? minPosCubes[cubeData[1]] : null, numOfCubes);
                }
            }

            foreach(string key in  minPosCubes.Keys)
            {
                totalPower *= minPosCubes[key];
            }

            Console.WriteLine($"Game {gameId}: {totalPower}");
            return totalPower;
        }

        private static int? FindHighestCubeValue(int? curVal, int numOfCubes)
        {
            if (curVal != null && curVal > numOfCubes)
                return curVal;

            return numOfCubes;
        }
    }
}
