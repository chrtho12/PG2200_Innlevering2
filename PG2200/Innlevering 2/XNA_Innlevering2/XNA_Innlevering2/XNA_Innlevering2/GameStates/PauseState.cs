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


namespace XNA_Innlevering2.GameStates
{

    public class PauseState : GameState
    {
        private GraphicsDevice _graphics;

         public PauseState(GameStateManager gameStateManager, GraphicsDevice graphics)
            : base(gameStateManager, graphics)
        {
            _graphics = graphics;
        }


        public override void initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            _graphics.Clear(Color.Turquoise);
        }
    }
}
