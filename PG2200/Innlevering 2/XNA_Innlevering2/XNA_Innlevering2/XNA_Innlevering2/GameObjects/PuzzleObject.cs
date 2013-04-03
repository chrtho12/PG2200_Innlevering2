using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace XNA_Innlevering2.GameObjects
{
    class PuzzleObject
    {
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
        public int Answer { get; set; }

        private Random random;

        public PuzzleObject()
        {
            random = new Random();

            FirstNumber = random.Next(1, 8);
            SecondNumber = random.Next(1, 8);

            Answer = FirstNumber + SecondNumber;
        }
    }
}
