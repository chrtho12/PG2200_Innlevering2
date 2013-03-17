using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Innlevering2.GameObjects
{

    public class GameObject
    {
        public Vector2 Position { get; private set; }
        public Texture2D Sprite { get; private set; }
        public Rectangle Bounds { get; private set; }

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
