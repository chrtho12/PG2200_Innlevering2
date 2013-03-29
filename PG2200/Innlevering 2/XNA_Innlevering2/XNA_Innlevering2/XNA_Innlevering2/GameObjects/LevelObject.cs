using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Map
{
    public class LevelObject
    {
        private int _heightOffset = 0;
        private int _widthOffset = 0;

        private Texture2D _tile;
        private Vector2 _size;

        public LevelObject(Texture2D tile, Vector2 size)
        {
            _tile = tile;
            _size = size;
        }
    }
}
