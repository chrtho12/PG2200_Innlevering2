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
            
            //don't set a decal by default
            Decal = null;

            //define collision boundries around sprite
            Bounds = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public GameObject(Texture2D sprite, Vector2 position, Texture2D decal) : this(sprite, position)
        {
            //if a decal is passed into the constructor, set the decal for the object
            Decal = decal;
        }


    }
}
