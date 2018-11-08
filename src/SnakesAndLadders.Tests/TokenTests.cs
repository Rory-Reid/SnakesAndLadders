using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests
{
    [TestClass]
    public class TokenTests
    {
        [TestMethod]
        public void PlaceOnBoard_WhenPassedBoard_SetsCurrentSquareToBoardStartSquare()
        {
            var sut = new Token();

            sut.PlaceOnBoard(new BoardStub(5, 10));

            Assert.AreEqual(5, sut.CurrentSquare);
        }

        [TestMethod]
        public void MoveSpaces_AfterTokenPlacedOnBoard_MovesToNextValidSpaceOnBoard()
        {
            var sut = new Token();
            sut.PlaceOnBoard(new BoardStub());

            sut.MoveSpaces(5);

            Assert.AreEqual(28, sut.CurrentSquare);
        }

        private class BoardStub : Board
        {
            int start;
            int end;

            public BoardStub(int startSquare = 1, int endSquare = 100)
            {
                start = startSquare;
                end = endSquare;
            }

            public override int StartSquare => start;
            public override int EndSquare => end;

            public override int GetNextValidSpace(int current, int spacesToMove)
            {
                // Might want to improve this so we can validate the input, if we really care about that interaction?
                return 28;
            }
        }
    }
}
