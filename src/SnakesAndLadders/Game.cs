namespace SnakesAndLadders
{
    public class Game
    {
        Token player;

        public Game(Board gameBoard, Token player)
        {
            this.player = player;
            Board = gameBoard;
        }

        public Token ActiveToken { get; private set; }
        public Board Board { get; }

        public void Start()
        {
            ActiveToken = player;
        }
    }
}
