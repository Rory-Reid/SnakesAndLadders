using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SnakesAndLadders.Tests
{
    [TestClass]
    public class BoardTests
    {
        /// <summary>
        /// Snakes and ladders starts on square 1, finishes on square 100. That's the rules.
        /// </summary>
        [TestMethod]
        public void Ctor_Always_SetsStartAndEndSquaresToExpectedValues()
        {
            var sut = new Board();

            Assert.AreEqual(1, sut.StartSquare);
            Assert.AreEqual(100, sut.EndSquare);
        }

        /// <summary>
        /// A valid amount of spaces may be moving from square 19 to 22
        /// It is not valid to move beyond the end space
        /// </summary>
        [TestMethod]
        public void GetNextValidSpace_WhenMovingAValidAmountOfSpaces_ReturnsExpectedNextSpace()
        {
            var sut = new Board();

            var nextSpace = sut.GetNextValidSpace(19, 3);

            Assert.AreEqual(22, nextSpace);
        }

        [TestMethod]
        public void GetNextValidSpace_WhenMovingToEnd_ReturnsEndSpace()
        {
            var sut = new Board();
            var fiveSpacesBeforeTheEnd = sut.EndSquare - 5;

            var nextSpace = sut.GetNextValidSpace(fiveSpacesBeforeTheEnd, 5);

            Assert.AreEqual(sut.EndSquare, nextSpace);
        }

        /// <summary>
        /// It's not valid to move past the end space. You must land directly on it.
        /// </summary>
        [TestMethod]
        public void GetNextValidSpace_IfAttemptingToMoveBeyondEndSpace_ReturnsCurrentSpace()
        {
            var sut = new Board();
            var fiveSpacesBeforeTheEnd = sut.EndSquare - 5;

            var nextSpace = sut.GetNextValidSpace(fiveSpacesBeforeTheEnd, sut.EndSquare + 1);

            Assert.AreEqual(fiveSpacesBeforeTheEnd, nextSpace);
        }
    }
}
