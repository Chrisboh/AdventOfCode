using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"C:\src\AOC\AOCDay9\input.txt");

        List<Node> knots = new List<Node>();
        for (int ii = 0; ii < 10; ii++)
            knots.Add(new Node());

        foreach (string line in lines)
        {
            string[] parts = line.Split(" ");
            char direction = parts[0][0];
            int numOfSteps = int.Parse(parts[1]);

            for (int ii = 0; ii < numOfSteps; ii++)
            {
                switch (direction)
                {
                    case 'U':
                        knots[0].Y++;
                        break;
                    case 'L':
                        knots[0].X--;
                        break;
                    case 'D':
                        knots[0].Y--;
                        break;
                    case 'R':
                        knots[0].X++;
                        break;
                    default:
                        break;
                }

                for (int jj = 0; jj < knots.Count() - 1; jj++)
                {
                    Console.WriteLine("Knot({0}): {1}, {2}", jj.ToString(), knots[jj].X.ToString(), knots[jj].Y.ToString());
                    UpdateTail(knots[jj], knots[jj+1]);
                }

                Console.WriteLine("Knot(9): {0}, {1}", knots[9].X.ToString(), knots[9].Y.ToString());
                Console.WriteLine("\n======================\n");
            }            
        }

        Console.WriteLine(knots.Last().LocationsVisited.Distinct().Count());
    }

    private static void UpdateTail(Node head, Node tail)
    {
        int xDist = head.X - tail.X;
        int yDist = head.Y - tail.Y;

        if (Math.Abs(xDist) > 1 && Math.Abs(yDist) > 1)
        {
            if(xDist > 0 && yDist > 0)
            {
                tail.X++;
                tail.Y++;
            }    
            else if( xDist > 0 && yDist < 0) 
            {
                tail.X++;
                tail.Y--;
            }
            else if( xDist < 0 && yDist < 0)
            {
                tail.X--;
                tail.Y--;
            }
            else
            {
                tail.X--;
                tail.Y++;
            }
        }
        else if ( Math.Abs(xDist) > 1 )
        {
            if (xDist < 0)
                tail.X--;
            else
                tail.X++;

           tail.Y = head.Y;
        }
        else if(Math.Abs(yDist) > 1)
        {
            if (yDist < 0)
                tail.Y--;
            else
                tail.Y++;

            tail.X = head.X;
        }

        tail.LocationsVisited.Add($"{tail.X} {tail.Y}");
    }
}

public class Node
{
    public int X { get; set; }
    public int Y { get; set; }
    public List<string> LocationsVisited { get; set; } = new List<string>();

    public Node (int x = 0, int y = 0)
    {
        X = x;
        Y = y;
    }
}