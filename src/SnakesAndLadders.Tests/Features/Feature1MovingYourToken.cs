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
        public void TokenCanMoveAcrossTheBoard1()
        {
            // Given
            TheGameIsStarted();

            // When
            TheTokenIsPlacedOnTheBoard();

            // Then
            TheTokenIsOnSquare(1);
        }

        [TestMethod]
        public void TokenCanMoveAcrossTheBoard2()
        {
            // Given
            TheTokenIsCurrentlyOnSquare(1);

            // When
            TheTokenIsMovedForward(3);

            // Then
            TheTokenIsOnSquare(4);
        }

        [TestMethod]
        public void TokenCanMoveAcrossTheBoard3()
        {
            // Given
            TheTokenIsCurrentlyOnSquare(1);

            // When
            TheTokenIsMovedForward(3);
            TheTokenIsMovedForward(4);

            // Then
            TheTokenIsOnSquare(8);
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
            game = new Game(new Board(), new Token());
            game.Start();
        }

        private void TheTokenIsCurrentlyOnSquare(int square)
        {
            game.ActiveToken.CurrentSquare = square;
        }

        private void TheTokenIsPlacedOnTheBoard()
        {
            game.ActiveToken.PlaceOnBoard(game.Board);
        }

        private void TheTokenIsMovedForward(int spacesToMove)
        {
            game.ActiveToken.MoveSpaces(spacesToMove);
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
