using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XNA_Innlevering2.Abstract;
using XNA_Innlevering2.GameComponents;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2
{
    public class Game1 : Game
    {
        //set window properties
        public const int WindowHeight = 800;
        public const int WindowWidth = 600;

        //create a player and a camera for the scene
        private Camera _camera;
        private CollisionComponent _collisionComponent;
        private InputManager _inputManager;
        private InterfaceComponent _interfaceComponent;
        private PlayerObject _player;
        private SceneManager _sceneManager;
        private SoundComponent _soundComponent;
        private SpriteComponent _spriteComponent;
        private GraphicsDeviceManager graphics;

        private SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            //instantiate new components and managers, assign as services
            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof (SpriteComponent), _spriteComponent);

            _soundComponent = new SoundComponent(this);
            Services.AddService(typeof (SoundComponent), _soundComponent);

            _interfaceComponent = new InterfaceComponent(this);
            Services.AddService(typeof (InterfaceComponent), _interfaceComponent);

            _collisionComponent = new CollisionComponent(this);
            Services.AddService(typeof (CollisionComponent), _collisionComponent);

            _camera = new Camera();
            Services.AddService(typeof (Camera), _camera);

            _inputManager = new InputManager(this);

            _sceneManager = new SceneManager(this);

            Content.RootDirectory = "Content";

            //hide default mouse cursor; will use own version instead
            IsMouseVisible = false;

            //set the resolution 
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
        }


        protected override void Initialize()
        {
            //add the components to run parallell methods with game1.cs
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

            //add keys and descriptions for input manager:

            //player actions:
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

            //sound actions:
            _inputManager.AddAction("pause/resume music");
            _inputManager["pause/resume music"].Add(Keys.P);
            _inputManager.AddAction("change track");
            _inputManager["change track"].Add(Keys.O);
            _inputManager.AddAction("adjust volume up");
            _inputManager["adjust volume up"].Add(Keys.I);
            _inputManager.AddAction("adjust volume down");
            _inputManager["adjust volume down"].Add(Keys.K);

            //generate a new 4x4 level (currently only supports 4 by 4)
            _sceneManager.GenerateNewLevel(new Vector2(4, 4));
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            //update the input manager
            _inputManager.Update();

            //retrieve player as service
            _player = (PlayerObject) Services.GetService(typeof (PlayerObject));

            //to exit, press escape
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //check if the different keys in the input manager are pressed
            if (_inputManager["move up"].IsDown)
            {
                //link player and camera movement
                _player.Move(new Vector2(0f, -10f));
                _camera.Move(new Vector2(0f, -10f));
            }

            if (_inputManager["move down"].IsDown)
            {
                _player.Move(new Vector2(0f, 10f));
                _camera.Move(new Vector2(0f, 10f));
            }

            if (_inputManager["move left"].IsDown)
            {
                _player.Move(new Vector2(-10f, 0f));
                _camera.Move(new Vector2(-10f, 0f));
            }

            if (_inputManager["move right"].IsDown)
            {
                _player.Move(new Vector2(10f, 0f));
                _camera.Move(new Vector2(10f, 0f));
            }

            //activate action
            if (_inputManager["activate"].IsTapped)
                _player.Activate();

            // ajust sound options
            if (_inputManager["pause/resume music"].IsTapped)
                _soundComponent.PauseBackgroundMusic();

            if (_inputManager["change track"].IsTapped)
                _soundComponent.PlayBackgroundMusic();

            if (_inputManager["adjust volume up"].IsTapped)
                _soundComponent.AdjustVolumeUp();

            if (_inputManager["adjust volume down"].IsTapped)
                _soundComponent.AdjustVolumeDown();

            //if player every finds the puzzle answer and his boolean is set to true, load a new level
            if (_player.HasWon)
            {
                _sceneManager.GenerateNewLevel(new Vector2(4, 4));
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //nothing to draw here :(

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}