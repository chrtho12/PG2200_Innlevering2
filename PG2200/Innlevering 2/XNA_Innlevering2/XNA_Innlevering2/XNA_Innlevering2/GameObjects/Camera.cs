using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_Innlevering2.GameComponents;

namespace XNA_Innlevering2.GameObjects
{
    public class Camera
    {
        public SpriteBatch SpriteBatch { get; set; }

        public Vector2 position { get; set; }
        public Matrix transform { get; set; }

        private InputManager _inputManager;

        public Camera()
        {
            position = Vector2.Zero;
            _inputManager = new InputManager();

            _inputManager.AddAction("move camera up");
            _inputManager["move camera up"].Add(Keys.W);
            _inputManager.AddAction("move camera down");
            _inputManager["move camera down"].Add(Keys.S);
            _inputManager.AddAction("move camera left");
            _inputManager["move camera left"].Add(Keys.A);
            _inputManager.AddAction("move camera right");
            _inputManager["move camera right"].Add(Keys.D);
        }

        public void Move(Vector2 amount)
        {
            position += amount;
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateTranslation(new Vector3(Game1.WindowWidth * 0.15f, Game1.WindowHeight * 0.35f, 0));

            return transform;
        }

        public void Update()
        {
            _inputManager.Update();

            if (_inputManager["move camera up"].IsDown)
                Move(new Vector2(0f, -10f));
            if (_inputManager["move camera down"].IsDown)
                Move(new Vector2(0f, 10f));
            if (_inputManager["move camera left"].IsDown)
                Move(new Vector2(-10f, 0f));
            if (_inputManager["move camera right"].IsDown)
                Move(new Vector2(10f, 0f));

        }

        
    }

}
