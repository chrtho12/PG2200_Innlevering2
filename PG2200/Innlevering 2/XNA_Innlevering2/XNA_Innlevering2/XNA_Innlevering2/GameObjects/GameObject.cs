using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.Abstract;

namespace XNA_Innlevering2.GameObjects
{
    public class GameObject
    {
        public Vector2 Position;
        public Texture2D Sprite;
        public Rectangle Bounds;

        public GameObject(Texture2D sprite, Vector2 position)
        {
            Position = position;
            Sprite = sprite;
        }

        public GameObject(Vector2 position)
        {
            Position = position;
            Sprite = null;
        }

    }
}
