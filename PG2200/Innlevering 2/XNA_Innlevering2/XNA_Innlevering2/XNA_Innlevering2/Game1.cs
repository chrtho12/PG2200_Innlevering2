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

        private InterfaceComponent _interfaceComponent;

        private SceneManager _sceneManager;

        public const int WindowHeight = 800;
        public const int WindowWidth = 600;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof(SpriteComponent), _spriteComponent);    

            _interfaceComponent = new InterfaceComponent(this);
            Services.AddService(typeof(InterfaceComponent), _interfaceComponent);    

            _collisionComponent = new CollisionComponent(this);
            Services.AddService(typeof(CollisionComponent), _collisionComponent);    

            _sceneManager = new SceneManager(this);
            
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

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _sceneManager.GenerateNewLevel(new Vector2(4, 4));

        }

        protected override void UnloadContent()
        {
        }


        protected override void Update(GameTime gameTime)
        {
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
    }
}
