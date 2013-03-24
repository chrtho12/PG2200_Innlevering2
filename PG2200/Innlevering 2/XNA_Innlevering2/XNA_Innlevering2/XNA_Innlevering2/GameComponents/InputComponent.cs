using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using XNA_Innlevering2.Abstract;
using XNA_Innlevering2.GameObjects;


namespace XNA_Innlevering2
{

    interface IControllable
    {
        void KeyboardState();
    }

    public class InputComponent : GameComponent
    {
        private MouseState currentMouseState, previousMouseState;
        private KeyboardState currentKeyboardState, previousKeyboardState;
        
        public InputComponent(Game game)
            : base(game)
        {
        }

        public override void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            GetKeyboardState();

            base.Update(gameTime);
        }

        public void GetKeyboardState()
        {
            if(currentKeyboardState.IsKeyDown(Keys.W))
            {
                Camera.Move(new Vector2(0f, -10f));
            }

            if (currentKeyboardState.IsKeyDown(Keys.S))
            {
                Camera.Move(new Vector2(0f, 10f));
            }

            if (currentKeyboardState.IsKeyDown(Keys.A))
            {
                Camera.Move(new Vector2(-10f, 0f));
            }

            if (currentKeyboardState.IsKeyDown(Keys.D))
            {
                Camera.Move(new Vector2(10f, 0f));
            }

        }
    }
}
