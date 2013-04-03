using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_Innlevering2.GameComponents;

namespace XNA_Innlevering2.GameObjects
{
    public class PlayerObject : GameObject
    {
        private float _speed;

        private InputManager _inputManager;

        public PlayerObject(Texture2D sprite, Vector2 position) : base(sprite, position)
        {
            _inputManager = new InputManager();
            
            _inputManager.AddAction("move up");
            _inputManager["move up"].Add(Keys.Up);
            _inputManager.AddAction("move down");
            _inputManager["move down"].Add(Keys.Down);
            _inputManager.AddAction("move left");
            _inputManager["move left"].Add(Keys.Left);
            _inputManager.AddAction("move right");
            _inputManager["move right"].Add(Keys.Right);
            _inputManager.AddAction("activate");
            _inputManager["activate"].Add(Keys.Space);
        }


        public void Update()
        {
            Bounds.X = (int)Position.X;
            Bounds.Y = (int)Position.Y;

            _inputManager.Update();

            if (_inputManager["move up"].IsDown) //and collision is true
                this.Position.Y -= 10;
                
            if (_inputManager["move down"].IsDown)
                this.Position.Y += 10;

            if (_inputManager["move left"].IsDown)
                this.Position.X -= 10;

            if (_inputManager["move right"].IsDown)
                this.Position.X += 10;

            if (_inputManager["activate"].IsDown)
                Console.WriteLine("activate!");
        }

        
    }
}