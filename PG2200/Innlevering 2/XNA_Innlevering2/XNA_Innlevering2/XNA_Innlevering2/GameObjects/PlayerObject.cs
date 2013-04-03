using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_Innlevering2.Abstract;
using XNA_Innlevering2.GameComponents;

namespace XNA_Innlevering2.GameObjects
{
    public class PlayerObject : GameObject
    {
        public bool IsColliding { get; set; }
        public bool HasActivated { get; set; }

        public PlayerObject(Texture2D sprite, Vector2 position) : base(sprite, position)
        { }

        public void Move(Vector2 amount)
        {
            Position += amount;    
        }

        public void Activate()
        {
            if (IsColliding)
            {
                HasActivated = true;
                Console.WriteLine("activated!");
            }
            
        }

        public void Update()
        {
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;

            IsColliding = false;

        }

        
    }
}