namespace SnakesAndLadders
{
    public class Token
    {
        private Board currentBoard;

        public virtual int CurrentSquare { get; set; }

        public void PlaceOnBoard(Board board)
        {
            currentBoard = board;
            CurrentSquare = board.StartSquare;
        }

        public virtual void MoveSpaces(int amountToMove)
        {
            var nextSpace = currentBoard.GetNextValidSpace(CurrentSquare, amountToMove);
            CurrentSquare = nextSpace;
        }
    }
}
