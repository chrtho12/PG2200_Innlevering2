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
    public class LevelManager : DrawableGameComponent
    {
        private List<TileObject> _currentLevel;
        private SpriteBatch _spriteBatch;

        private Camera _camera = new Camera();

        public int LevelCount { get; private set; }

        public LevelManager(Game game)
            : base(game)
        {}

        protected override void LoadContent()
        {
            base.LoadContent();

            Camera.position = new Vector2(20f, 50f);

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            Console.WriteLine("loading levelManager content...");
        }

        public override void Initialize()
        {
            _currentLevel = new List<TileObject>();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, _camera.GetTransformation(GraphicsDevice));

            _currentLevel.ForEach(o => _spriteBatch.Draw(o.Sprite, o.Position, Color.White));

            _spriteBatch.End();
        }

        public void BuildNewLevel(Vector2 size)
        {
            Console.WriteLine("building level...");

            _currentLevel.Clear();

            int heightOffset = 0;
            int widthOffset = 0;

            Texture2D tile = Game.Content.Load<Texture2D>(@"sprites\BlockTile");

            for (int i = 0; i < size.Y; i++)
            {
                for (int j = 0; j < size.X; j++)
                {
                    _currentLevel.Add(new TileObject(tile, new Vector2(widthOffset, heightOffset)));
                    widthOffset += tile.Width;
                }

                heightOffset += tile.Height / 2;
                widthOffset = 0;
            }

            LevelCount++;

            Console.WriteLine("level: " + LevelCount);
            Console.WriteLine("contains: " + _currentLevel.Count + " number of tileObjects");

        }
    }
}
