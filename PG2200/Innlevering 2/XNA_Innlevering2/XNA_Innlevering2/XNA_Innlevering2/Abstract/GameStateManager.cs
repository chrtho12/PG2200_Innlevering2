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
using XNA_Innlevering2.GameStates;


namespace XNA_Innlevering2.Abstract
{
    public class GameStateManager : DrawableGameComponent
    {
        private LinkedList<GameState> _states;
        private SpriteBatch _spriteBatch;
        
        public GameStateManager(Game game)
            : base(game)
        {
            _states = new LinkedList<GameState>();
        }

        public void Push(GameState state)
        {
            _states.AddFirst(state);
            Console.WriteLine("State pushed onto stack: " + state);
        }

        public void Pop()
        {
            _states.RemoveFirst();
            Console.WriteLine("State removed from stack");
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
            if (_states.First.Value.StopUpdate)
                _states.First.Value.Update(gameTime);

            base.Update(gameTime);
        }

        private void _Draw(LinkedListNode<GameState> node, GameTime gameTime)
        {
            //node.Value.Draw(gameTime);

            //if (!node.Value.StopDraw)
            //    _Draw(node.Next, gameTime);
        }
        
        public override void Draw(GameTime gameTime)
        {
            if (_states.First.Value.StopDraw)
                _states.First.Value.Draw(gameTime);     
        }

        
    }

    

}
