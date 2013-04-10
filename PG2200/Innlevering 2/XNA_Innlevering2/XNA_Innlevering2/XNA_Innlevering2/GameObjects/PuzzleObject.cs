using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNA_Innlevering2.GameObjects
{
    class PuzzleObject
    {
        //each objective is its own object that can be passed around
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public int Answer { get; set; }

        private Random random;

        public PuzzleObject()
        {
            // a new random object
            random = new Random();

            //sets random numbers for both number values
            FirstNumber = random.Next(1, 8);
            SecondNumber = random.Next(1, 8);

            //stores the answer value by adding the first and second number
            Answer = FirstNumber + SecondNumber;
        }
    }
}
