using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.Abstract;

namespace XNA_Innlevering2.GameStates
{
    public class PlayingState : GameState
    {
        private GraphicsDevice _graphics;
        public new GameComponentCollection _components;

        public PlayingState(GameStateManager gameStateManager, GraphicsDevice graphics)
            : base(gameStateManager, graphics)
        {
            _graphics = graphics;
        }

        public override void initialize()
        {
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            _graphics.Clear(Color.YellowGreen);
        }
    }
}
