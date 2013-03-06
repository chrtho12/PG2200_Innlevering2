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


namespace XNA_Innlevering2
{

    public interface IInputService
    {
        void GetKeyboardState();
    }

    public class InputComponent : Microsoft.Xna.Framework.GameComponent, IInputService
    {
        private MouseState currentMouseState, previousMouseState;
        private KeyboardState currentKeyboardState, previousKeyboardState;
        
        public InputComponent(Game game)
            : base(game)
        {
            game.Services.AddService(typeof(IInputService), this);
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
            if (currentKeyboardState != previousKeyboardState)
            {
                Console.WriteLine("PRESS!");
            }
        }
    }
}
