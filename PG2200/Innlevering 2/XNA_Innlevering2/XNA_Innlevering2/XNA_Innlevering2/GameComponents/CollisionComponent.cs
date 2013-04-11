using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameObjects;
using XNA_Innlevering2.Abstract;


namespace XNA_Innlevering2.Abstract
{
    public class CollisionComponent : GameComponent, IListable
    {
        // the list of scene objects
        private List<GameObject> _sceneObjects;

        public bool IsColliding;

        public CollisionComponent(Game game)
            : base(game)
        { }

        public override void Initialize()
        {
            //create a new list, assign it to the scene objects
            _sceneObjects = new List<GameObject>();
            
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            //retrieve services
            PlayerObject _player = (PlayerObject)Game.Services.GetService(typeof(PlayerObject));
            PuzzleObject _puzzle = (PuzzleObject)Game.Services.GetService(typeof (PuzzleObject));

            //iterate over every object that has been sent to the list and check if they collide with the player
            foreach (var obj in _sceneObjects.Where(obj => _player.Bounds.Intersects(obj.Bounds)))
            {
                //if the player collides AND he collides with a an object with a decal index that corresponds to the puzzle answer AND he has activated it...
                if ((obj.Index == _puzzle.Answer) && _player.HasActivated)
                {
                    //... player wins, and a new level is loaded
                    _player.HasWon = true;
                }
            }

            base.Update(gameTime);
        }

        public void AddTo(GameObject gameObject)
        {
            //add object to list
            if (gameObject == null || _sceneObjects.Contains(gameObject))
                return;

            _sceneObjects.Add(gameObject);
        }

        public void RemoveFrom(GameObject gameObject)
        {
            //remove object from list
            _sceneObjects.Remove(gameObject);
        }

        public void Clear()
        {
            //clear the scene for objects completely
            _sceneObjects.Clear();
        }
    }
}
