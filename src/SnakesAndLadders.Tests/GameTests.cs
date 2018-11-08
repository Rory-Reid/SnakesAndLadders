using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Ctor_Always_SetsGameBoard()
        {
            var board = new BoardStub();

            var sut = new Game(board, new TokenStub(), new DiceStub());

            Assert.AreEqual(board, sut.Board);
        }

        [TestMethod]
        public void Ctor_Never_SetsActivePlayer()
        {
            var sut = new Game(new BoardStub(), new TokenStub(), new DiceStub());

            Assert.IsNull(sut.ActiveToken);
        }

        /// <summary>
        /// In the future, I expect we'll inject some player factory which maybe has the facility to create the (variable)
        /// number of players on the fly as the game starts? For now, we'll just inject and use a single token since
        /// this feature does not expect more than that.
        /// </summary>
        [TestMethod]
        public void Start_Always_SetsActiveTokenToInjectedPlayer()
        {
            var player = new TokenStub();
            var sut = new Game(new BoardStub(), player, new DiceStub());

            sut.Start();

            Assert.AreEqual(player, sut.ActiveToken);
        }

        [TestMethod]
        public void MovePlayer_AfterGameHasStarted_UsesCurrentDiceRollToMoveToken()
        {
            var player = new TokenStub();
            var dice = new DiceStub();
            var sut = new Game(new BoardStub(), player, new DiceStub());

            sut.Start();

            sut.MoveActiveToken();
        }

        private class BoardStub : Board
        {
        }

        private class TokenStub : Token
        {
            private int position = 0; // Initialise to 0 for these tests. Measure changes from there.

            public override int CurrentSquare => position;

            public override void MoveSpaces(int amountToMove)
            {
            }
        }

        private class DiceStub : Dice
        {
            public DiceStub() : base(new RandomStub())
            {
            }

            public override int Result => 6;

            private class RandomStub : Random { }
        }
    }
}
