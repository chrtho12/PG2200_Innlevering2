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


namespace XNA_Innlevering2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        //private InputComponent _inputHandler;
        private NewInputManager _newInputManager;
        
        
        private SpriteComponent _spriteComponent;
        //private LevelManager _levelManager;

        private NewLevelManager _newLevelManager;

        private PlayerObject _player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            //_inputHandler = new InputComponent(this);
            _newInputManager = new NewInputManager(this);

            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof(SpriteComponent), _spriteComponent);    

            //_levelManager = new LevelManager(this);
            _newLevelManager = new NewLevelManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


        }


        protected override void Initialize()
        {
            //Components.Add(_levelManager);
            //Components.Add(_inputHandler);
            Components.Add(_spriteComponent);
            Components.Add(_newInputManager);

            base.Initialize();
            
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Console.WriteLine("loading game1 content...");

            //_levelManager.BuildNewLevel(new Vector2(4, 4));

            _newLevelManager.GenerateNewLevel(new Vector2(4,4));
            
            SpawnPlayer();
                
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

            

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();


            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void SpawnPlayer()
        {
            _player = new PlayerObject(Content.Load<Texture2D>(@"sprites\Player"), new Vector2(0, 0));
            _spriteComponent.AddNew(_player);
        }
    }
}
