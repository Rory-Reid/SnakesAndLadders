using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SnakesAndLadders.Tests
{
    [TestClass]
    public class DiceTests
    {
        /// <summary>
        /// Stub's always going to return 5 here. Expect 5.
        /// </summary>
        [TestMethod]
        public void Roll_Always_SetsResultToNextRngNumber()
        {
            var sut = new Dice(new RandomStub());

            sut.Roll();

            Assert.AreEqual(5, sut.Result);
        }

        private class RandomStub : Random
        {
            public override int Next(int minValue, int maxValue)
            {
                if (minValue != 1)
                {
                    throw new ArgumentException("The smallest number on a six-sided dice should be 1");
                }

                if (maxValue != 6)
                {
                    throw new ArgumentException("The largest number on a six-sided dice should be 6");
                }

                return 5;
            }
        }
    }
}
