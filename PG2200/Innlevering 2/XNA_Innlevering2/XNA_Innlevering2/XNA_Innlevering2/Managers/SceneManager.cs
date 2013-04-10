using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameComponents;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Abstract
{
    class SceneManager : GameComponent
    {
        private int _levelIndex = 0;
        public PuzzleObject CurrentPuzzle { get; set; }

        public PlayerObject Player;
        
        private Random _random;
        private int _levelSize = 16;

        private SpriteComponent _spriteComponent;
        private CollisionComponent _collisionComponent;

        private Dictionary<int, Texture2D> _answerContainer; 

        //Scene manager constructor, instantiantes a random, and retrieves services
        public SceneManager(Game game) : base(game)
        {
            _random = new Random();

            _spriteComponent = (SpriteComponent)Game.Services.GetService(typeof(SpriteComponent));
            _collisionComponent = (CollisionComponent) Game.Services.GetService(typeof (CollisionComponent));

        }
        
        public void GenerateNewLevel(Vector2 size)
        {
            //these clear the sprite- and- collision objects every time a new level is generated
            _spriteComponent.ClearDrawables();
            _collisionComponent.ClearCollidables();

            //offset values to increment and layout the map
            int heightOffset = 0;
            int widthOffset = 0;

            //this container holds the decals that overlay each tile, and a corresponding int-value to compare them with
            _answerContainer = new Dictionary<int, Texture2D>();
            LoadDecals();

            //load texture for the tiles
            Texture2D tile = Game.Content.Load<Texture2D>(@"sprites\BlockTile");

            //for every column of the map...
            for (int i = 0; i < size.Y; i++)
            {
                //for every row of the map...
                for (int j = 0; j < size.X; j++)
                {
                    // assign a new random value to the current decal to be assigned
                    int currentDecalIndex = _random.Next(1, _levelSize - 1);

                    //create a new game object and assign it the tile texture. Also assign the currently stored tile decal with its corresponding index value
                    GameObject newTile = new GameObject(tile, new Vector2(widthOffset, heightOffset),
                        _answerContainer.Values.ElementAt(currentDecalIndex))
                        {Index = _answerContainer.Keys.ElementAt(currentDecalIndex)};

                    //add the object as a sprite and a collision object
                    _spriteComponent.AddToDrawables(newTile);
                    _collisionComponent.AddToCollidables(newTile);

                    //increment wdith offset, in anticipation of a new object to be created
                    widthOffset += tile.Width;    
                    
                }

                //increment height offset and reset the width offset for a new row
                heightOffset += tile.Height / 2;
                widthOffset = 0;
            }

            //increment the int value of the level index
            _levelIndex++;
            
            // Regenerate puzzle, player and UI
            CreateNewPuzzle();
            SpawnPlayer();        
            RefreshUI();
        }

        public void LoadDecals()
        {
            //populates the answer container, according to level size and how the decal files are stored under the decals-directory
            for (int i = 1; i < _levelSize; i++)
            {
                _answerContainer.Add(i, Game.Content.Load<Texture2D>(@"decals\" + i));
            }
        }

        public void CreateNewPuzzle()
        {
            // check if an object is assigned to the current service. If so, remove it and create a new object reference.
            if (Game.Services.GetService(typeof(PuzzleObject)) != null)
            {
                Game.Services.RemoveService(typeof(PuzzleObject));
            }
            
            CurrentPuzzle = new PuzzleObject();
            Game.Services.AddService(typeof(PuzzleObject), CurrentPuzzle);
            
        }


        public void SpawnPlayer()
        {
            // check if an object is assigned to the current service. If so, remove it and create a new object reference.
            if (Game.Services.GetService(typeof(PlayerObject)) != null)
            {
                Game.Services.RemoveService(typeof(PlayerObject));
            }

            Player = new PlayerObject(Game.Content.Load<Texture2D>(@"sprites\Player"), new Vector2(0, 0));
            Game.Services.AddService(typeof(PlayerObject), Player);    
            _spriteComponent.AddToDrawables(Player);

        }
        
        public void RefreshUI()
        {
            //refresh the UI values
            InterfaceComponent interfaceComponent =
                (InterfaceComponent)Game.Services.GetService(typeof(InterfaceComponent));

            interfaceComponent.Refresh(_levelIndex, CurrentPuzzle.FirstNumber + "+" + CurrentPuzzle.SecondNumber);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Player.Update();
        }
    }
}
