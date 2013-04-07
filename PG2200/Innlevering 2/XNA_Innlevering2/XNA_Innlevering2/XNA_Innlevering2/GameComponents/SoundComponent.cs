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
    public class SoundComponent : GameComponent
    {
        private Dictionary<string, SoundEffect> _soundEffectLibrary;
        private PlayerObject _player;
        private bool _isPaused = false;
        private bool _isLow = false;
        private bool _isPlayingFirstSong = false;

        private int _timer;
        private int _soundInterval = 10;
        private Random random;

        private List<Song> _musicLibrary; 
        
        public SoundComponent(Game game)
            : base(game)
        {}

        public override void Initialize()
        {
            _musicLibrary = new List<Song>
                {
                    Game.Content.Load<Song>(@"soundfx\music1"),
                    Game.Content.Load<Song>(@"soundfx\music2")
                };

            _soundEffectLibrary = new Dictionary<string, SoundEffect>
                {
                    {"walk", Game.Content.Load<SoundEffect>(@"soundfx\walk")},
                    {"fail", Game.Content.Load<SoundEffect>(@"soundfx\fail")},
                    {"succeed", Game.Content.Load<SoundEffect>(@"soundfx\succeed")}
                };

            random = new Random();

            PlayBackgroundMusic();

            base.Initialize();
        }

        
        public void PlaySoundEffect(string name)
        {
            if (_timer >= _soundInterval)
            {
                _soundEffectLibrary[name].Play();
                _timer = 0;
            }

            else
                _timer++;
        }

        public void PlayBackgroundMusic()
        {

            if (_isPlayingFirstSong)
            {
                MediaPlayer.Play(_musicLibrary[1]);
                _isPlayingFirstSong = false;
            }

            else
            {
                MediaPlayer.Play(_musicLibrary[0]);
                _isPlayingFirstSong = true;
            }

            InterfaceComponent.SoundActive = true;
        }

        public void StopBackgroundMusic()
        {
            InterfaceComponent.SoundActive = false;
            MediaPlayer.Stop();
        }

        public void AdjustVolumeUp()
        {
            MediaPlayer.Volume += 0.1f;
        }

        public void AdjustVolumeDown()
        {
            MediaPlayer.Volume -= 0.1f;
        }

        public void PauseBackgroundMusic()
        {
            if (!_isPaused)
            {
                MediaPlayer.Pause();
                _isPaused = true;
                InterfaceComponent.SoundActive = false;
            } else
            {
                MediaPlayer.Resume();
                InterfaceComponent.SoundActive = true;
                _isPaused = false;
            }
        }

        public override void Update(GameTime gameTime)
        {

            _player = (PlayerObject)Game.Services.GetService(typeof(PlayerObject));

            if (InterfaceComponent.SoundClicked)
            {
                StopBackgroundMusic();
                InterfaceComponent.SoundClicked = false;
            }

            if (_player.HasActivated && _player.HasWon)
            {
                _soundEffectLibrary["succeed"].Play();
                _player.HasActivated = false;
            }

            if (_player.isWalking)
            {
                PlaySoundEffect("walk");
                _player.isWalking = false;
            }

            if (_player.HasActivated && !_player.HasWon)
            {
                PlaySoundEffect("fail");
                _player.HasActivated = false;
            }

            base.Update(gameTime);
        }
    }
}
