using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests.Features
{
    [TestClass]
    public class Feature1MovingYourToken
    {
        Game game;

        [TestMethod]
        public void TokenCanMoveAcrossTheBoard()
        {
            // Given
            TheGameIsStarted();

            // When
            TheTokenIsPlacedOnTheBoard();

            // Then
            TheTokenIsOnSquare(1);
        }

        private void TheGameIsStarted()
        {
            game = new Game();
            game.Start();
        }

        private void TheTokenIsPlacedOnTheBoard()
        {
            game.ActiveToken.PlaceOnBoard(game.Board);
        }

        private void TheTokenIsOnSquare(int squareNumber)
        {
            Assert.AreEqual(squareNumber, game.ActiveToken.CurrentSquare);
        }
    }
}
