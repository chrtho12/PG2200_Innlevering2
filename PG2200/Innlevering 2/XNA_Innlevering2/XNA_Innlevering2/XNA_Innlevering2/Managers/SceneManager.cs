﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.GameComponents;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2.Abstract
{
    class SceneManager : GameComponent
    {
        private int _levelIndex = 0;
        private PuzzleObject _currentPuzzleObject;

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

        public void GenerateNewLevel(Vector2 size)
        {
            _spriteComponent.ClearDrawables();

            int heightOffset = 0;
            int widthOffset = 0;
            _answerContainer = new Dictionary<int, Texture2D>();

            Texture2D tile = Game.Content.Load<Texture2D>(@"sprites\BlockTile");

            List<int> previousDecalIndexes = new List<int>();

            LoadDecals();
            
            for (int i = 0; i < size.Y; i++)
            {
                for (int j = 0; j < size.X; j++)
                {
                    int currentDecalIndex = _random.Next(1, _levelSize - 1);
                    previousDecalIndexes.Add(currentDecalIndex);

                    GameObject newTile = new GameObject(tile, new Vector2(widthOffset, heightOffset), _answerContainer.Values.ElementAt(currentDecalIndex));
                    _spriteComponent.AddToDrawables(newTile);
                    _collisionComponent.AddToCollidables(newTile);
                    
                    widthOffset += tile.Width;

                }

                heightOffset += tile.Height / 2;
                widthOffset = 0;
            }

            _levelIndex++;
            _currentPuzzleObject = new PuzzleObject();
            
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


        public void SpawnPlayer()
        {
            Player = new PlayerObject(Game.Content.Load<Texture2D>(@"sprites\Player"), new Vector2(0, 0));
            Game.Services.AddService(typeof(PlayerObject), Player);

             _spriteComponent.AddToDrawables(Player);
        }
        
        public void RefreshUI()
        {
            InterfaceComponent interfaceComponent =
                (InterfaceComponent)Game.Services.GetService(typeof(InterfaceComponent));

            interfaceComponent.Refresh(_levelIndex, _currentPuzzleObject.FirstNumber + "+" + _currentPuzzleObject.SecondNumber);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Player.Update();
        }
    }
}
