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

        private int _cameraBoundLeft = -400;
        private int _cameraBoundRight = 400;
        private int _cameraBoundUp = 400;
        private int _cameraBoundDown = -400;

        public Camera()
        {
            position = Vector2.Zero;
        }

        public void Move(Vector2 amount)
        {
            position += amount;

            if (position.X >= _cameraBoundRight)
               position = new Vector2(_cameraBoundRight, position.Y);
            if (position.X <= _cameraBoundLeft)
                position = new Vector2(_cameraBoundLeft, position.Y);
            if (position.Y >= _cameraBoundUp)
                position = new Vector2(position.X, _cameraBoundUp);
            if (position.Y <= _cameraBoundDown)
                position = new Vector2(position.X, _cameraBoundDown);
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateTranslation(new Vector3(Game1.WindowWidth * 0.15f, Game1.WindowHeight * 0.35f, 0));

            return transform;
        }
        
    }

}
