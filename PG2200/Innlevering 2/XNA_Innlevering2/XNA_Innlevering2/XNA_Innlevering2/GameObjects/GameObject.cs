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
        public Texture2D Decal;
        public Rectangle Bounds;
        public int Index;

        public GameObject(Texture2D sprite, Vector2 position)
        {
            Position = position;
            Sprite = sprite;
            Decal = null;

            Bounds = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height / 2);
        }

        public GameObject(Texture2D sprite, Vector2 position, Texture2D decal) : this(sprite, position)
        {
            Decal = decal;
        }


    }
}
