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
        private string _instructionText = "[Arrow keys] to move character\n      [Space] to activate tile";

        private Vector2 _levelIndicatorSpace;
        private Vector2 _puzzleToSolveSpace;
        private Vector2 _instructionSpace;
        private Rectangle _soundIconSpace;

        private Texture2D _soundIcon;

        private MouseState _currentMouseState;
        private Rectangle _mousePosition;
        private Texture2D _cursor;

        public static bool SoundActive { get; set; }
        public static bool SoundClicked { get; set; }

        public InterfaceComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            // the interface component has its own spritebatch, seperate from the spritecomponent
            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            //load graphics for the font, icon and cursor
            UIFont = Game.Content.Load<SpriteFont>(@"fonts\UIFont");
            _soundIcon = Game.Content.Load<Texture2D>(@"sprites\sound");
            _cursor = Game.Content.Load<Texture2D>(@"sprites\cursor");

            //define areas on the screen where the graphics go
            _levelIndicatorSpace = new Vector2(Game1.WindowWidth / 8f, 20);
            _puzzleToSolveSpace = new Vector2(Game1.WindowWidth / 2f, 20);
            _instructionSpace = new Vector2(Game1.WindowWidth / 5f, Game1.WindowHeight / 1.15f);
            _soundIconSpace = new Rectangle(0, Game1.WindowHeight - _soundIcon.Height, _soundIcon.Width, _soundIcon.Height);
        }

        public override void Update(GameTime gameTime)
        {
            //get the state of the mouse
            _currentMouseState = Mouse.GetState();

            //create a rectangle that follows the mouse
            _mousePosition = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 25, 25);

            //checks if mouse is over sound icon and is pressed
            if (_mousePosition.Intersects(_soundIconSpace) && _currentMouseState.LeftButton == ButtonState.Pressed)
            {
                //the sound is clicked
                SoundClicked = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();

            //draw the sound icon. If sound is active, load the misty rose color. If not, load the dark red.
            _spriteBatch.Draw(_soundIcon, _soundIconSpace, SoundActive ? Color.MistyRose : Color.DarkRed);

            //draw the spritefonts with the different variables that increment levels and puzzles
            _spriteBatch.DrawString(UIFont, "Level: " + _levelText, _levelIndicatorSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, "Puzzle: " + _puzzleText, _puzzleToSolveSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, _instructionText, _instructionSpace, Color.MistyRose);

            //draw the cursor graphics
            _spriteBatch.Draw(_cursor, _mousePosition, Color.MistyRose);

            _spriteBatch.End();

        }

        public void Refresh(int level, string puzzle)
        {
            //method to refresh the UI and set the new puzzle and level text
            _levelText = level;
            _puzzleText = puzzle;
        }
    }
}
