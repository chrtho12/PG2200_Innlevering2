using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Map
{
    public class MapObject
    {
        public List<TileObject> TileList { get; private set; } 
              
        public MapObject()
        {
            TileList = new List<TileObject>();
        }

    }
}
