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
        private List<TileObject> _level; 

        private Texture2D _tile;
        private Vector2 _size;

        public LevelObject(Texture2D tile, Vector2 size)
        {
            _tile = tile;
            _size = size;

            Generate();
        }

        private void Generate()
        {
            int heightOffset = 0;
            int widthOffset = 0;

            for (int i = 0; i < _size.Y; i++)
            {
                for (int j = 0; j < _size.X; j++)
                {
                    _level.Add(new TileObject(_tile, new Vector2(widthOffset, heightOffset)));
                    widthOffset += _tile.Width;
                }

                heightOffset += _tile.Height / 2;
                widthOffset = 0;
            }
        }
    }
}
