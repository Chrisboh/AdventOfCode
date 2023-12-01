internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines(@"d:\src\AdventOfCode\AOCDay10\input.txt");
        int instructionPtr = 0;
        bool isExecuting = false;
        int xReg = 1;
        int screenPos = 1;
        int spritePos = 2;        
        Instruction currentInst = null;

        for (int cycle = 1; cycle <= 240; cycle++)
        {
            if (screenPos >= spritePos - 1 && screenPos <= spritePos + 1)
                Console.Write("#");
            else
                Console.Write(".");

            if (!isExecuting)
            {
                isExecuting= true;

                string[] data = lines[instructionPtr].Split(" ");
                if (data.Count() == 2)
                    currentInst = new Instruction(data[0], cycle + 1, int.Parse(data[1])); // addx
                else
                    currentInst = new Instruction(data[0], cycle); // noop

                instructionPtr++;
            }

            if(currentInst != null && currentInst.EndingCycle == cycle)
            {
                if(currentInst.Name == "addx")
                {
                    xReg += currentInst.Value;
                    spritePos = xReg + 1;
                }

                isExecuting= false;
            }

            if (cycle == 40 || cycle == 80 || cycle == 120 || cycle == 160 || cycle == 200 || cycle == 240)
            {
                screenPos = 0;
                spritePos = 2;
                Console.WriteLine();
            }

            screenPos++;
        }
    }

    public class Instruction
    {
        public string Name { get; set; }
        public int EndingCycle { get; set; }
        public int Value { get; set; }

        public Instruction(string name, int endingCycle, int value = 0)
        {
            Name = name;
            EndingCycle = endingCycle;
            Value = value;
        }
    }
}