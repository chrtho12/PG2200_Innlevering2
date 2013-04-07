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

            _spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            UIFont = Game.Content.Load<SpriteFont>(@"fonts\UIFont");
            _soundIcon = Game.Content.Load<Texture2D>(@"sprites\sound");
            _cursor = Game.Content.Load<Texture2D>(@"sprites\cursor");

            _levelIndicatorSpace = new Vector2(Game1.WindowWidth / 8f, 20);
            _puzzleToSolveSpace = new Vector2(Game1.WindowWidth / 2f, 20);
            _instructionSpace = new Vector2(Game1.WindowWidth / 5f, Game1.WindowHeight / 1.15f);
            _soundIconSpace = new Rectangle(0, Game1.WindowHeight - _soundIcon.Height, _soundIcon.Width, _soundIcon.Height);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            _currentMouseState = Mouse.GetState();

            _mousePosition = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 25, 25);

            if (_mousePosition.Intersects(_soundIconSpace) && _currentMouseState.LeftButton == ButtonState.Pressed)
            {
                SoundClicked = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.Draw(_soundIcon, _soundIconSpace, SoundActive ? Color.MistyRose : Color.DarkRed);

            _spriteBatch.DrawString(UIFont, "Level: " + _levelText, _levelIndicatorSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, "Puzzle: " + _puzzleText, _puzzleToSolveSpace, Color.MistyRose);
            _spriteBatch.DrawString(UIFont, _instructionText, _instructionSpace, Color.MistyRose);

            _spriteBatch.Draw(_cursor, _mousePosition, Color.MistyRose);

            _spriteBatch.End();

        }

        public void Refresh(int level, string puzzle)
        {
            _levelText = level;
            _puzzleText = puzzle;
        }
    }
}
