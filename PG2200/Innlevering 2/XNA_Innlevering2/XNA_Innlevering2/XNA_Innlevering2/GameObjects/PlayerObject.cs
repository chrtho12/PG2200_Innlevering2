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
        //booleans to track current player states
        public bool HasActivated { get; set; }
        public bool HasWon { get; set; }
        public bool isWalking { get; set; }
        public bool isFlying { get; set; }
        
        //sets the speed, currently only at default/base value
        private float _speed = 1.0f;

        public PlayerObject(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            HasWon = false;
            HasActivated = false;
        }

        public void Move(Vector2 amount)
        {
            Position += amount * _speed;

            //restrain the player movements inside the playing field
            if (Position.X >= 375)
               Position = new Vector2(375, Position.Y);
            if (Position.X <= -25)
                Position = new Vector2(-25, Position.Y);
            if (Position.Y <= -5)
                Position = new Vector2(Position.X, -5);
            if (Position.Y >= 260)
                Position = new Vector2(Position.X, 260);

            //indicate that the player is moving
            isWalking = true;
        }

        public void Activate()
        {
            //if player activates a tile when not walking, indicate he has activated
            if (!isWalking)
                HasActivated = true;
        }

        public void Update()
        {
            //trace collision boundries with sprite position
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;
        }

        
    }
}