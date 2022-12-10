internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"C:\src\AOC\AOCDay2\input.txt");
        int totalPoints = 0;

        // Opponent: A = Rock B = Paper C = Scissors
        // ME: X = Lose Y = Draw Z = Win
        // Scores: Rock = 1 Paper = 2 Scissors = 3 Loss = 0 Draw = 3 Win = 6

        foreach (string line in lines)
        {
            char opp = line[0];
            char me = line[2];

            if (line == "A X" || line == "B X" || line == "C X")
            {
                // We lose
                totalPoints += GetPoints(GetHand(opp, result.Lose));
            }
            else if (line == "A Y" || line == "B Y" || line == "C Y")
            {
                // We Draw
                totalPoints += GetPoints(GetHand(opp, result.Draw)) + 3;
            }
            else
            {
                // We Win
                totalPoints += GetPoints(GetHand(opp, result.Win)) + 6;
            }
        }

        Console.WriteLine(totalPoints);
    }

    public enum result
    {
        Lose,
        Draw,
        Win
    }

    public static int GetPoints(char hand)
    {
        if (hand == 'X')
            return 1;
        else if (hand == 'Y')
            return 2;
        else
            return 3;
    }

    public static char GetHand(char oppHand, result res)
    {
        switch (res)
        {
            case result.Lose:
                if (oppHand == 'A')
                    return 'Z';
                else if (oppHand == 'B')
                    return 'X';
                else
                    return 'Y';
            case result.Draw:
                if (oppHand == 'A')
                    return 'X';
                else if (oppHand == 'B')
                    return 'Y';
                else
                    return 'Z';
            case result.Win:
                if (oppHand == 'A')
                    return 'Y';
                else if (oppHand == 'B')
                    return 'Z';
                else
                    return 'X';
            default:
                return 'G';
        }
    }
}