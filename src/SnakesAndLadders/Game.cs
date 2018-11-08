namespace SnakesAndLadders
{
    public class Game
    {
        Token player;
        Dice dice;

        public Game(Board gameBoard, Token player, Dice dice)
        {
            this.player = player;
            this.dice = dice;
            Board = gameBoard;
        }

        public Token ActiveToken { get; private set; }
        public Board Board { get; }

        public void Start()
        {
            ActiveToken = player;
        }

        public void MoveActiveToken()
        {
            ActiveToken.MoveSpaces(dice.Result);
        }
    }
}
