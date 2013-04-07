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

        public bool IsColliding;

        public CollisionComponent(Game game)
            : base(game)
        { }

        public override void Initialize()
        {
            _sceneObjects = new List<GameObject>();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            PlayerObject _player = (PlayerObject)Game.Services.GetService(typeof(PlayerObject));
            PuzzleObject _puzzle = (PuzzleObject)Game.Services.GetService(typeof (PuzzleObject));

            foreach (var obj in _sceneObjects.Where(obj => _player.Bounds.Intersects(obj.Bounds)))
            {
                if ((obj.Index == _puzzle.Answer) && _player.HasActivated)
                {
                    _player.HasWon = true;
                }
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
