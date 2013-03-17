using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNA_Innlevering2.Abstract;
using XNA_Innlevering2.GameComponents;
using XNA_Innlevering2.GameObjects;
using XNA_Innlevering2.GameStates;
using XNA_Innlevering2.Map;

namespace XNA_Innlevering2
{

    //TODO: revise the camera class and functionality - reason for weird draw artifacts with the tiles.

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        private InputComponent inputHandler;
        private SoundEffectComponent soundManager;
        private TextRenderingComponent textManager;
        private ObjectCollisionComponent collisionManager;
        private LevelManagerComponent levelManager;

        private GameStateManager _gameStates;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            inputHandler = new InputComponent(this);
            soundManager = new SoundEffectComponent(this);
            textManager = new TextRenderingComponent(this);
            collisionManager = new ObjectCollisionComponent(this);
            levelManager = new LevelManagerComponent(this, Content);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _gameStates = new GameStateManager(this);
            _gameStates.Push(new PauseState(_gameStates, graphics));

        }


        protected override void Initialize()
        {
            //add the different game objects to the game's components list
            Components.Add(inputHandler);
            Components.Add(soundManager);
            Components.Add(textManager);
            Components.Add(collisionManager);
            Components.Add(levelManager);

            base.Initialize();

            Services.AddService(typeof(SpriteBatch), spriteBatch);

        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            // TODO: use this.Content to load your game content here

        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            // TODO: Add your drawing code here

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
