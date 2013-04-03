using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Abstract
{
    interface IMyDrawable
    {
        void AddToDrawables(GameObject gameObject);
        void RemoveFromDrawables(GameObject gameObject);
        void ClearDrawables();
    }

    public class SpriteComponent : DrawableGameComponent, IMyDrawable
    {
        private List<GameObject> _sceneObjects;
        
        private SpriteBatch _spriteBatch;

        private Camera _camera;

        public SpriteComponent(Game game)
            : base(game)
        {
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
        }

        public override void Initialize()
        {
            _sceneObjects = new List<GameObject>();
            _camera = new Camera();

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _camera.Update();

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _camera.GetTransformation(GraphicsDevice));

                foreach (GameObject o in _sceneObjects)
                {
                    _spriteBatch.Draw(o.Sprite, o.Position, Color.White);

                    if (o.Decal != null)
                    {
                        _spriteBatch.Draw(o.Decal, o.Position, Color.White);
                    }
                }

            _spriteBatch.End();
        }

        public void AddToDrawables(GameObject gameObject)
        {
            if (gameObject == null || _sceneObjects.Contains(gameObject))
                return;

            _sceneObjects.Add(gameObject);
        }

        public void RemoveFromDrawables(GameObject gameObject)
        {
            _sceneObjects.Remove(gameObject);
        }

        public void ClearDrawables()
        {
            _sceneObjects.Clear();
        }

    }
}
