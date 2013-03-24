using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_Innlevering2.GameObjects
{
    public class Camera
    {
        public static SpriteBatch SpriteBatch { get; set; }

        public static Vector2 position { get; set; }
        public Matrix transform { get; set; }

        public Camera()
        {
            position = Vector2.Zero;
        }

        public static void Move(Vector2 amount)
        {
            position += amount;
        }

        public Matrix GetTransformation(GraphicsDevice graphicsDevice)
        {
            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) * Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));

            return transform;
        }

    }

}
