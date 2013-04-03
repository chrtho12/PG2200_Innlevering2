using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;
using XNA_Innlevering2.Abstract;


namespace XNA_Innlevering2.Abstract
{
    interface ICollidable
    {
        void AddToCollidables(GameObject gameObject);
        void RemoveFromCollidables(GameObject gameObject);
        void ClearCollidables();
    }

    public class CollisionComponent : GameComponent, ICollidable
    {
        private List<GameObject> _sceneObjects;
        private PlayerObject _player;

        public CollisionComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public override void Initialize()
        {
            _sceneObjects = new List<GameObject>();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _player = (PlayerObject)Game.Services.GetService(typeof(PlayerObject));

            foreach (var obj in _sceneObjects.Where(obj => _player.Bounds.Intersects(obj.Bounds)))
            {
                Console.WriteLine("collision at: " + obj.Position.X + "," + obj.Position.Y);
            }
            
            base.Update(gameTime);
        }

        public void AddToCollidables(GameObject gameObject)
        {
            if (gameObject == null || _sceneObjects.Contains(gameObject))
                return;

            _sceneObjects.Add(gameObject);
        }

        public void RemoveFromCollidables(GameObject gameObject)
        {
            _sceneObjects.Remove(gameObject);
        }

        public void ClearCollidables()
        {
            _sceneObjects.Clear();
        }
    }
}
