using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests.Features
{
    [TestClass]
    public class Feature1MovingYourToken
    {
        Game game;
        RandomFake random;
        Dice dice;

        [TestInitialize]
        public void Initialise()
        {
            random = new RandomFake();
            dice = new Dice(random);

            game = new Game(new Board(), new Token(), dice);
        }

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
            SetupActiveGame();
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
            SetupActiveGame();
            TheTokenIsCurrentlyOnSquare(1);

            // When
            TheTokenIsMovedForward(3);
            TheTokenIsMovedForward(4);

            // Then
            TheTokenIsOnSquare(8);
        }

        [TestMethod]
        public void MovesAreDeterminedByDiceRolls1()
        {
            // Given
            TheGameIsStarted();

            // When
            ThePlayerRollsADie();

            // Then
            TheResultShouldBeBetween1To6Inclusive();
        }

        [TestMethod]
        public void MovesAreDeterminedByDiceRolls2()
        {
            // Given
            SetupActiveGame();
            ThePlayerRollsA(4);

            // When
            ThePlayerMovesTheirToken();

            // Then
            TheTokenShouldMoveSpaces(4);
        }

        private void SetupActiveGame()
        {
            TheGameIsStarted();
            TheTokenIsPlacedOnTheBoard();
        }

        // Given
        private void TheGameIsStarted()
        {
            game.Start();
        }

        private void TheTokenIsCurrentlyOnSquare(int square)
        {
            game.ActiveToken.CurrentSquare = square;
        }

        private void ThePlayerRollsA(int value)
        {
            // Force the dice's random number generator to explicity return a specific value on next roll.
            random.SetNextValue(value);
            dice.Roll();
        }

        // When
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

        private void ThePlayerMovesTheirToken()
        {
            game.MoveActiveToken();
        }

        // Then
        private void TheTokenIsOnSquare(int squareNumber)
        {
            Assert.AreEqual(squareNumber, game.ActiveToken.CurrentSquare);
        }

        private void TheResultShouldBeBetween1To6Inclusive()
        {
            Assert.IsTrue(dice.Result >= 1 && dice.Result <= 6);
        }

        private void TheTokenShouldMoveSpaces(int amountOfSpacesTheTokenShouldHaveMoved)
        {
            // Weakness for now - this only validates spaces moved from the start. Not massively reusable
            var expectedSpace = game.Board.StartSquare + amountOfSpacesTheTokenShouldHaveMoved;
            Assert.AreEqual(expectedSpace, game.ActiveToken.CurrentSquare);
        }

        private class RandomFake : Random
        {
            bool fakeNextValue = false;
            int nextValue = 0;

            public void SetNextValue(int value)
            {
                fakeNextValue = true;
                nextValue = value;
            }

            public override int Next(int minValue, int maxValue)
            {
                if (fakeNextValue)
                {
                    return nextValue;
                }
                else
                {
                    return base.Next(minValue, maxValue);
                }
            }
        }
    }
}
