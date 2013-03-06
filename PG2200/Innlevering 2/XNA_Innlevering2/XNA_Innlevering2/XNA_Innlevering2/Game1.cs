using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNA_Innlevering2.GameComponents;
using XNA_Innlevering2.GameObjects;

namespace XNA_Innlevering2
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        //initialize fields for the different game components
        private InputComponent inputHandler;
        private SoundEffectComponent soundHandler;
        private TextRenderingComponent textHandler;
        private ObjectCollisionComponent collisionHandler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            inputHandler = new InputComponent(this);
            soundHandler = new SoundEffectComponent(this);
            textHandler = new TextRenderingComponent(this);
            collisionHandler = new ObjectCollisionComponent(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            
        }

  
        protected override void Initialize()
        {
            //add the different game objects to the game's components list
            Components.Add(inputHandler);
            Components.Add(soundHandler);
            Components.Add(textHandler);
            Components.Add(collisionHandler);

            base.Initialize();
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
