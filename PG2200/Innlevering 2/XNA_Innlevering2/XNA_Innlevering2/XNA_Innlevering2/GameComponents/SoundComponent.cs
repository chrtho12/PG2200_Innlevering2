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
using XNA_Innlevering2.GameObjects;


namespace XNA_Innlevering2.GameComponents
{
    public class SoundComponent : Microsoft.Xna.Framework.GameComponent
    {
        private Dictionary<string, SoundEffect> _soundBank;
        private PlayerObject _player;
        private bool _isPlaying = false;

        private int _timer;
        private int _soundInterval = 10;
        
        public SoundComponent(Game game)
            : base(game)
        {}

        public override void Initialize()
        {
            
            _soundBank = new Dictionary<string, SoundEffect>
                {
                    {"walk", Game.Content.Load<SoundEffect>(@"soundfx\walk")},
                    {"music", Game.Content.Load<SoundEffect>(@"soundfx\music")},
                    {"fail", Game.Content.Load<SoundEffect>(@"soundfx\fail")},
                    {"succeed", Game.Content.Load<SoundEffect>(@"soundfx\succeed")}
                };

            PlayBackgoundMusic();

            base.Initialize();
        }

        public void PlaySound(string name)
        {
            if (_timer >= _soundInterval)
            {
                _soundBank[name].Play();
                _timer = 0;
            }

            else
                _timer++;
        }

        public void PlayBackgoundMusic()
        {
            SoundEffectInstance bgmusic = _soundBank["music"].CreateInstance();
            bgmusic.IsLooped = true;
            bgmusic.Play();
        }

        public override void Update(GameTime gameTime)
        {
            _player = (PlayerObject)Game.Services.GetService(typeof(PlayerObject));

            if (_player.HasActivated && _player.HasWon)
            {
                _soundBank["succeed"].Play();
                _player.HasActivated = false;
            }

            if (_player.Walking)
            {
                PlaySound("walk");
                _player.Walking = false;
            }

            if (_player.HasActivated && !_player.HasWon)
            {
                PlaySound("fail");
                _player.HasActivated = false;
            }

            base.Update(gameTime);
        }
    }
}
