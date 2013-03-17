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


namespace XNA_Innlevering2.Abstract
{
    
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameStateManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private LinkedList<GameState> _states;
        
        public GameStateManager(Game game)
            : base(game)
        {
            _states = null;
        }

        public void Push(GameState state)
        {
            _states.AddFirst(state);
        }

        public void Pop()
        {
            _states.RemoveFirst();
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            _Draw(_states.First, gameTime);
            
            base.Draw(gameTime);
        }

        private void _Draw(LinkedListNode<GameState> node, GameTime time)
        {
            node.Value.Draw(time);

            if(!node.Value.BlockDraw)
                _Draw(node.Next, time);
        }
    }

    public abstract class GameState
    {
        protected GameComponentCollection _components;

        public virtual bool BlockUpdate { get { return true; } }

        public virtual bool BlockDraw { get { return true; } }

        protected GameState(GameStateManager _stateManager, GraphicsDevice graphics, SpriteBatch spriteBatch) // TODO: create a new spritebatch in constructor instead?
        { }

        public abstract void initialize();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime);

    }

}
