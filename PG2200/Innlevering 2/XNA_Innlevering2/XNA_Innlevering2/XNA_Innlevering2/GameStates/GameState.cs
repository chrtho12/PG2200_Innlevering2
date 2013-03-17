using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNA_Innlevering2.Abstract;

namespace XNA_Innlevering2.GameStates
{
    public abstract class GameState
    {
        protected GameComponentCollection _components;

        public virtual bool StopUpdate { get { return true; } }

        public virtual bool StopDraw { get { return true; } }

        protected GameState(GameStateManager _stateManager, GraphicsDevice graphics)
        {}

        public abstract void initialize();

        public new abstract void Update(GameTime gameTime);

        public new abstract void Draw(GameTime gameTime);

    }
}
