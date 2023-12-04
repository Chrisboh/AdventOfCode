namespace AOCDay3
{
    internal class NumberData
    {
        public int Value { get; set; }
        public int LineNumber { get; set; }
        public int StartingPos { get; set; }
        public int EndingPos { get; set; }

        public NumberData(int value, int lineNum, int startPos, int endPos)
        {
            Value = value;
            LineNumber = lineNum;
            StartingPos = startPos;
            EndingPos = endPos;
        }

        public bool IsInRange(int linenum, int starStartpos, int starEndpos)
        {
            if(linenum != LineNumber)
                return false;

            if ((EndingPos >= starStartpos && StartingPos <= starEndpos) || starEndpos >= StartingPos && starStartpos <= EndingPos) 
                return true;

            return false;
        }
    }
}