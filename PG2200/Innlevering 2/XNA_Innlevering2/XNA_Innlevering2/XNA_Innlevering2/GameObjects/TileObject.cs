using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Innlevering2.GameObjects
{
    public class TileObject : GameObject 
    {
        public Texture2D Decal { get; set; }
        
        public TileObject(Texture2D sprite, Vector2 position, Texture2D decal) : base(sprite, position)
        {
            Decal = decal;
        }

        public TileObject(Vector2 position) : base(position)
        {}

        public TileObject( Texture2D sprite, Vector2 position)
            : base(sprite, position)
        {}
       
    }

}
