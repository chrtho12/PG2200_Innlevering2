using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNA_Innlevering2.GameObjects;
using XNA_Innlevering2.Map;


namespace XNA_Innlevering2.Abstract
{
    
    public class LevelManagerComponent : DrawableGameComponent
    {
        private MapObject _currentLevel;
        private ContentManager _content;

        public int _levelCounter { get; private set; }

        public LevelManagerComponent(Game game, ContentManager content)
            : base(game)
        {
            _content = content;
        }

        protected override void LoadContent()
        {
            _levelCounter = 0;
            _currentLevel = GenerateNewLevel(new Vector2(5,5));

        }

        public override void Initialize()
        {
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch spriteBatch = Game.Services.GetService(typeof(SpriteBatch)) as SpriteBatch;

            if (spriteBatch != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, Camera.GetTransformation(GraphicsDevice));

                if (_currentLevel != null)
                    _currentLevel.TileList.ForEach(o => spriteBatch.Draw(o.Sprite, o.Position, Color.White));

            spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        private MapObject GenerateNewLevel(Vector2 size)
        {
            MapObject NewLevel = new MapObject();
            
            Texture2D tile = _content.Load<Texture2D>(@"sprites\BlockTile");
            int tileHeightOffset = 0;
            int tileWidthOffset = 0;
            
            for (int i = 0; i < size.Y; i++)
            {
                for (int j = 0; j < size.X; j++)
                {
                    NewLevel.TileList.Add(new TileObject(tile, new Vector2(tileWidthOffset, tileHeightOffset)));
                    tileWidthOffset += tile.Width;
                }

                tileHeightOffset += tile.Height / 2;
                tileWidthOffset = 0;
            }

            _levelCounter++;

            //DEBUG
            Console.WriteLine("New Level, Count: " + _levelCounter);
            Console.WriteLine("Added number of Blocks: " + NewLevel.TileList.Count);

            return NewLevel;
        }
    }
}
