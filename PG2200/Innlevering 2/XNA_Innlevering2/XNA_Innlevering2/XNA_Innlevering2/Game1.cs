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

        private SpriteComponent _spriteComponent;
        private CollisionComponent _collisionComponent;
        private SoundComponent _soundComponent;

        private InterfaceComponent _interfaceComponent;

        private SceneManager _sceneManager;
        private InputManager _inputManager;

        public const int WindowHeight = 800;
        public const int WindowWidth = 600;

        private PlayerObject _player;
        private Texture2D _playerTexture;
        private Camera _camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof(SpriteComponent), _spriteComponent);

            _soundComponent = new SoundComponent(this);
            Services.AddService(typeof(SoundComponent), _soundComponent);

            _interfaceComponent = new InterfaceComponent(this);
            Services.AddService(typeof(InterfaceComponent), _interfaceComponent);    

            _collisionComponent = new CollisionComponent(this);
            Services.AddService(typeof(CollisionComponent), _collisionComponent);    

            _inputManager = new InputManager(this);

            _sceneManager = new SceneManager(this);

            _camera = new Camera();
            Services.AddService(typeof(Camera), _camera);    
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
        }


        protected override void Initialize()
        {
            Components.Add(_spriteComponent);
            Components.Add(_interfaceComponent);
            Components.Add(_sceneManager);
            Components.Add(_collisionComponent);
            Components.Add(_inputManager);
            Components.Add(_soundComponent);

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);

            _inputManager.AddAction("move up");
            _inputManager["move up"].Add(Keys.Up);
            
            _inputManager.AddAction("move down");
            _inputManager["move down"].Add(Keys.Down);
            
            _inputManager.AddAction("move left");
            _inputManager["move left"].Add(Keys.Left);
            
            _inputManager.AddAction("move right");
            _inputManager["move right"].Add(Keys.Right);
            
            _inputManager.AddAction("activate");
            _inputManager["activate"].Add(Keys.Space);

            _inputManager.AddAction("move camera up");
            _inputManager["move camera up"].Add(Keys.W);
            
            _inputManager.AddAction("move camera down");
            _inputManager["move camera down"].Add(Keys.S);
            
            _inputManager.AddAction("move camera left");
            _inputManager["move camera left"].Add(Keys.A);
            
            _inputManager.AddAction("move camera right");
            _inputManager["move camera right"].Add(Keys.D);

            _sceneManager.GenerateNewLevel(new Vector2(4, 4));
        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

           _inputManager.Update();

            _player = (PlayerObject)Services.GetService(typeof(PlayerObject));
            
            if (_inputManager["move up"].IsDown)
                _player.Move(new Vector2(0f, -10f));

            if (_inputManager["move down"].IsDown)
                _player.Move(new Vector2(0f, 10f));

            if (_inputManager["move left"].IsDown)
                _player.Move(new Vector2(-10f, 0f));

            if (_inputManager["move right"].IsDown)
                _player.Move(new Vector2(10f, 0f));

            if (_inputManager["activate"].IsDown)
                _player.Activate();

            if (_inputManager["move camera up"].IsDown)
                _camera.Move(new Vector2(0f, -10f));

            if (_inputManager["move camera down"].IsDown)
                _camera.Move(new Vector2(0f, 10f));

            if (_inputManager["move camera left"].IsDown)
                _camera.Move(new Vector2(-10f, 0f));

            if (_inputManager["move camera right"].IsDown)
                _camera.Move(new Vector2(10f, 0f));


            if (_player.HasWon)
            {
                _sceneManager.GenerateNewLevel(new Vector2(4,4));
                _player.HasWon = false;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
