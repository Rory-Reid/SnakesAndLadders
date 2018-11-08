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

            var sut = new Game(board, new TokenStub());

            Assert.AreEqual(board, sut.Board);
        }

        [TestMethod]
        public void Ctor_Never_SetsActivePlayer()
        {
            var sut = new Game(new BoardStub(), new TokenStub());

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
            var sut = new Game(new BoardStub(), player);

            sut.Start();

            Assert.AreEqual(player, sut.ActiveToken);
        }

        private class BoardStub : Board
        {
        }

        private class TokenStub : Token
        {
        }
    }
}
