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
        private float _speed = 0.8f;

        public PlayerObject(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            HasWon = false;
            HasActivated = false;
            IsColliding = false;
        }

        public void Move(Vector2 amount)
        {
            Position += amount * _speed;

            if (Position.X >= 375)
               Position = new Vector2(375, Position.Y);
            if (Position.X <= -25)
                Position = new Vector2(-25, Position.Y);
            if (Position.Y <= -5)
                Position = new Vector2(Position.X, -5);
            if (Position.Y >= 260)
                Position = new Vector2(Position.X, 260);

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
        }

        
    }
}