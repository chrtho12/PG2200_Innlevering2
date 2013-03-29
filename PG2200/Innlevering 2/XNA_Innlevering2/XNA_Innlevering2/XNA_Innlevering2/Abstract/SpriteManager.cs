using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;
using XNA_Innlevering2.Map;

namespace XNA_Innlevering2.Abstract
{
    interface IDrawableSprite
    {
        void AddTo(GameObject gameObject);
        void RemoveFrom(GameObject gameObject);
    }

    public class SpriteManager : DrawableGameComponent, IDrawableSprite
    {
        private List<GameObject> _listOfDrawables;
        private SpriteBatch _spriteBatch;

        public SpriteManager(Game game)
            : base(game)
        {
            _listOfDrawables = new List<GameObject>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            Console.WriteLine("loading spriteManager content...");
            
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

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

            _spriteBatch.Begin();

            _listOfDrawables.ForEach(o => _spriteBatch.Draw(o.Sprite, o.Position, Color.White));

            _spriteBatch.End();
        }

        public void AddTo(GameObject gameObject)
        {
            if (gameObject == null || _listOfDrawables.Contains(gameObject))
                return;

            _listOfDrawables.Add(gameObject);
        }

        public void RemoveFrom(GameObject gameObject)
        {
            _listOfDrawables.Remove(gameObject);
        }
    }
}
