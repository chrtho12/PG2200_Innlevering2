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

        private LevelManager _levelManager;

        private PlayerObject _player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            _spriteComponent = new SpriteComponent(this);
            Services.AddService(typeof(SpriteComponent), _spriteComponent);    

            _levelManager = new LevelManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            Components.Add(_spriteComponent);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Console.WriteLine("loading game1 content...");

            _levelManager.GenerateNewLevel(new Vector2(4,4));

            _player = new PlayerObject(Content.Load<Texture2D>(@"sprites\Player"), new Vector2(0, 0));
            _spriteComponent.AddNew(_player);
            
                
            // TODO: use this.Content to load your game content here

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            _player.Update(gameTime);

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
