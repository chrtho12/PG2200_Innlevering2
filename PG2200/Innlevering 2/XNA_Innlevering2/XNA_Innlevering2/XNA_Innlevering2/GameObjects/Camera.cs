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

        //sets the camera boundries according to the background image
        private int _cameraBoundLeft = -200;
        private int _cameraBoundRight = 200;
        private int _cameraBoundDown = -100;
        private int _cameraBoundUp = 100;
        

        public Camera()
        {
            position = Vector2.Zero;
        }

        public void Move(Vector2 amount)
        {
            position += amount;

            //make sure camera can't move beyond its boundries
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
            //transform matrix to calculate how to draw the scene based on the camera movement
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateTranslation(new Vector3(Game1.WindowWidth * 0.15f, Game1.WindowHeight * 0.35f, 0));

            return transform;
        }
        
    }

}
