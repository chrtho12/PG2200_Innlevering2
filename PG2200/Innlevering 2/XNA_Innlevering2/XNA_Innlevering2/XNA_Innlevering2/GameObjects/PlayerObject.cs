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
        public bool HasWon { get; set; }
        public bool Walking { get; set; }

        public PlayerObject(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            HasWon = false;
            HasActivated = false;
            IsColliding = false;
        }

        public void Move(Vector2 amount)
        {
            Position += amount;
            Walking = true;
        }

        public void Activate()
        {
            if (!Walking)
                HasActivated = true;
        }

        public void Update()
        {
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;

            IsColliding = false;            
        }

        
    }
}