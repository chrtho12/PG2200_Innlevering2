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
    class GameManager : DrawableGameComponent, IDrawableSprite
    {
        private SpriteBatch _spriteBatch;
        private List<GameObject> _listOfDrawables;

        private int _levelCounter;

        public GameManager(Game game) : base(game)
        {
            _listOfDrawables = new List<GameObject>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
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

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Begin();

            foreach (GameObject gameObject in _listOfDrawables)
            {
                _spriteBatch.Draw(gameObject.Sprite, gameObject.Bounds, Color.White);
            }
            _spriteBatch.End();
        }
    }
}
