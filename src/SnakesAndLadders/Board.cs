namespace SnakesAndLadders
{
    public class Board
    {
        public virtual int StartSquare => 1;
        public virtual int EndSquare => 100;

        public virtual int GetNextValidSpace(int current, int spacesToMove)
        {
            var nextSpace = current + spacesToMove;
            if (nextSpace <= EndSquare)
            {
                return nextSpace;
            }
            else
            {
                return current;
            }
        }
    }
}
