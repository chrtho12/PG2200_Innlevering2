using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Abstract
{
    // the listable interface
    interface IListable
    {
        void AddTo(GameObject gameObject);
        void RemoveFrom(GameObject gameObject);
        void Clear();
    }

    public class SpriteComponent : DrawableGameComponent, IListable
    {
        //create a new list of scene objects
        private List<GameObject> _sceneObjects;
        
        //define the spritebatch that has to draw all the objects
        private SpriteBatch _spriteBatch;

        private Texture2D _backgroundImage;

        private Camera _camera;

        public SpriteComponent(Game game)
            : base(game)
        { }

        protected override void LoadContent()
        {
            base.LoadContent();

            //instantiate a new sprite batch
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);

           //retrieve and assign the camera from services, created in game1.cs
            _camera = (Camera)Game.Services.GetService(typeof(Camera));

            //load a background image
            _backgroundImage = Game.Content.Load<Texture2D>(@"sprites\bgscreen");
        }

        public override void Initialize()
        {
            //assign a new list to the scene object container
            _sceneObjects = new List<GameObject>();
            
            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            //begin drawing object as they are loaded (deferred), based on the camera translation
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, _camera.GetTransformation(GraphicsDevice));

            //draw the background image at the back
            _spriteBatch.Draw(_backgroundImage, new Vector2(-750, -500), Color.White);

            //for each object in the list...
            foreach (GameObject o in _sceneObjects)
            {
                //... draw the texture...
                _spriteBatch.Draw(o.Sprite, o.Position, Color.White);

                //... and the decal of that object, if applicable
                if (o.Decal != null)
                {
                    _spriteBatch.Draw(o.Decal, new Vector2(o.Position.X + (o.Sprite.Width / 3), o.Position.Y + (o.Sprite.Height / 5)), Color.White);
                }
            }

            //end drawing with spritebatch
            _spriteBatch.End();
        }

        public void AddTo(GameObject gameObject)
        {
            //add a drawable to the scene
            if (gameObject == null || _sceneObjects.Contains(gameObject))
                return;

            _sceneObjects.Add(gameObject);
        }

        public void RemoveFrom(GameObject gameObject)
        {
            //remove a drawable from the scene
            _sceneObjects.Remove(gameObject);
        }

        public void Clear()
        {
            //clear the scene of drawables
            _sceneObjects.Clear();
        }

    }
}
