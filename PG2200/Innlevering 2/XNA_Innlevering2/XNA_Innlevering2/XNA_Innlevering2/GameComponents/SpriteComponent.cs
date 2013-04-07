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

        private Texture2D _backgroundImage;

        private Camera _camera;

        public SpriteComponent(Game game)
            : base(game)
        {
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            _camera = (Camera)Game.Services.GetService(typeof(Camera));

            _backgroundImage = Game.Content.Load<Texture2D>(@"sprites\bgscreen");
        }

        public override void Initialize()
        {
            _sceneObjects = new List<GameObject>();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _camera.GetTransformation(GraphicsDevice));

            _spriteBatch.Draw(_backgroundImage, new Vector2(-750, -500), Color.White);

                foreach (GameObject o in _sceneObjects)
                {
                    _spriteBatch.Draw(o.Sprite, o.Position, Color.White);

                    if (o.Decal != null)
                    {
                        _spriteBatch.Draw(o.Decal, new Vector2(o.Position.X + (o.Sprite.Width / 3), o.Position.Y + (o.Sprite.Height / 5)), Color.White);
                    }

                    // TODO: endre player-texture til flyvende når ikke kolliderer
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
