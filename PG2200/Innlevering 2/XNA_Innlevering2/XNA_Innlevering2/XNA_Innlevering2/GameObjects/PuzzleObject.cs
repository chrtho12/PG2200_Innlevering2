using System;

namespace XNA_Innlevering2.GameObjects
{
    internal class PuzzleObject
    {
        //each objective is its own object that can be passed around
        private Random random;

        public PuzzleObject()
        {
            // a new random object
            random = new Random();

            //sets random numbers for both number values
            FirstNumber = random.Next(1, 9);
            SecondNumber = random.Next(0, 9);

            //stores the answer value by adding the first and second number
            Answer = FirstNumber + SecondNumber;
        }

        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public int Answer { get; set; }
    }
}