using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Innlevering2.GameObjects
{
    class GameObject : DrawableGameComponent
    {
        protected GameObject(Game game) : base(game)
        {
        }

        public Vector2 position { get; set; }
        public Texture2D sprite { get; set; }
        public Rectangle bounds { get; set; }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(sprite, position, Color.White);
        }

        public void Update()
        {
            bounds = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height); 
        }

    }
}
