using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA_Innlevering2.GameObjects
{
    abstract class BlockTile : GameObject
    {
        //public String SpriteLocation = @"sprites\BlockTile";
        protected BlockTile(Game game) : base(game)
        {
        }

        public Texture2D BlockTileDecal { get; set; }
    }

}
