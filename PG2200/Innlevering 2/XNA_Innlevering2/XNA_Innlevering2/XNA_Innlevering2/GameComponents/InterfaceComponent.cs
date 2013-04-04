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


namespace XNA_Innlevering2.GameComponents
{
    public class InterfaceComponent : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;

        private SpriteFont UIFont;
        
        private int _levelText;
        private string _puzzleText;
        private string _instructionText;

        private Vector2 _levelIndicatorSpace;
        private Vector2 _puzzleToSolveSpace;
        private Vector2 _instructionSpace;

        public InterfaceComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            UIFont = Game.Content.Load<SpriteFont>(@"fonts\UIFont");

            _levelIndicatorSpace = new Vector2(Game1.WindowWidth / 8f, 20);
            _puzzleToSolveSpace = new Vector2(Game1.WindowWidth / 2f, 20);
            _instructionSpace = new Vector2(Game1.WindowWidth / 5f, Game1.WindowHeight / 1.15f);
        }

        public override void Initialize()
        {
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
            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.DrawString(UIFont, "Level: " + _levelText, _levelIndicatorSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, "Puzzle: " + _puzzleText, _puzzleToSolveSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, "[Arrow keys] to move character\n      [WASD] to move camera\n        [Space] to activate tile", _instructionSpace, Color.MistyRose);

            _spriteBatch.End();

        }

        public void Refresh(int level, string puzzle)
        {
            _levelText = level;
            _puzzleText = puzzle;
        }
    }
}
