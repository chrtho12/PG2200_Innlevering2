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
using XNA_Innlevering2.GameObjects;


namespace XNA_Innlevering2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        public InputComponent inputHandler;
        private SpriteManager spriteManager;
        private LevelManager levelManager;

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            
            inputHandler = new InputComponent(this);
            spriteManager = new SpriteManager(this);
            levelManager = new LevelManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }


        protected override void Initialize()
        {
            Components.Add(levelManager);
            Components.Add(inputHandler);
            Components.Add(spriteManager);
            
            base.Initialize();
            
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Console.WriteLine("loading game1 content...");

            levelManager.BuildNewLevel(new Vector2(4, 4));
            
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
    }
}
