using System;

namespace SnakesAndLadders
{
    public class Dice
    {
        private Random randomNumberGenerator;

        public Dice(Random randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public virtual int Result { get; private set; }

        public void Roll()
        {
            Result = randomNumberGenerator.Next(1, 6);
        }
    }
}
