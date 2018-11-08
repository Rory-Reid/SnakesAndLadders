using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests.Features
{
    [TestClass]
    public class Feature1MovingYourToken
    {
        Game game;
        Dice dice = new Dice();

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

        [TestMethod]
        public void MovesAreDeterminedByDiceRolls()
        {
            // Given
            TheGameIsStarted();

            // When
            ThePlayerRollsADie();

            // Then
            TheResultShouldBeBetween1To6Inclusive();
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

        private void ThePlayerRollsADie()
        {
            dice.Roll();
        }

        private void TheTokenIsOnSquare(int squareNumber)
        {
            Assert.AreEqual(squareNumber, game.ActiveToken.CurrentSquare);
        }

        private void TheResultShouldBeBetween1To6Inclusive()
        {
            Assert.IsTrue(dice.Result >= 1 && dice.Result <= 6);
        }
    }
}
