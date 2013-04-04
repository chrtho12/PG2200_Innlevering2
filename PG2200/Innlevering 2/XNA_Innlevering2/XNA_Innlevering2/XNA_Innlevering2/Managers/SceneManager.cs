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

        public SceneManager(Game game) : base(game)
        {
            _random = new Random();

            _spriteComponent = (SpriteComponent)Game.Services.GetService(typeof(SpriteComponent));
            _collisionComponent = (CollisionComponent) Game.Services.GetService(typeof (CollisionComponent));

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void GenerateNewLevel(Vector2 size)
        {
            _spriteComponent.ClearDrawables();
            _collisionComponent.ClearCollidables();

            int heightOffset = 0;
            int widthOffset = 0;
            _answerContainer = new Dictionary<int, Texture2D>();

            Texture2D tile = Game.Content.Load<Texture2D>(@"sprites\BlockTile");

            LoadDecals();

            for (int i = 0; i < size.Y; i++)
            {
                for (int j = 0; j < size.X; j++)
                {
                    int currentDecalIndex = _random.Next(1, _levelSize - 1);

                    GameObject newTile = new GameObject(tile, new Vector2(widthOffset, heightOffset),
                        _answerContainer.Values.ElementAt(currentDecalIndex))
                        {Index = _answerContainer.Keys.ElementAt(currentDecalIndex)};

                    _spriteComponent.AddToDrawables(newTile);
                    _collisionComponent.AddToCollidables(newTile);

                    widthOffset += tile.Width;    
                    
                }

                heightOffset += tile.Height / 2;
                widthOffset = 0;
            }

            _levelIndex++;
            
            CreateNewPuzzle();

                SpawnPlayer();        
            
            
            RefreshUI();
        }

        public void LoadDecals()
        {
            for (int i = 1; i < _levelSize; i++)
            {
                _answerContainer.Add(i, Game.Content.Load<Texture2D>(@"decals\" + i));
            }
        }

        public void CreateNewPuzzle()
        {
            if (Game.Services.GetService(typeof(PuzzleObject)) != null)
            {
                Game.Services.RemoveService(typeof(PuzzleObject));
            }
            
            CurrentPuzzle = new PuzzleObject();
            Game.Services.AddService(typeof(PuzzleObject), CurrentPuzzle);
            
        }


        public void SpawnPlayer()
        {
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
