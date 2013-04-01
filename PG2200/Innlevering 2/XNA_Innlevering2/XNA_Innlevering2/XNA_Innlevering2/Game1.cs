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
        private InterfaceComponent _interfaceComponent;

        private LevelManager _levelManager;

        public const int WindowHeight = 800;
        public const int WindowWidth = 600;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof(SpriteComponent), _spriteComponent);    

            _interfaceComponent = new InterfaceComponent(this);
            Services.AddService(typeof(InterfaceComponent), _interfaceComponent);    

            _levelManager = new LevelManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
        }


        protected override void Initialize()
        {
            Components.Add(_spriteComponent);
            Components.Add(_interfaceComponent);
            Components.Add(_levelManager);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _levelManager.GenerateNewLevel(new Vector2(4, 4));

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
