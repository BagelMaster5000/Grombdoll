using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Grombdoll.Models.Systems {
    public static class AudioSystem {
        public static void InitializeMediaPlayers() {
            string path = Path.GetFullPath(@"Audio\SFX\gd-select1.wav");
            _select1.Open(new Uri(path));
            _select1.Volume = 1;
            _select1.Position = TimeSpan.MaxValue;

            path = Path.GetFullPath(@"Audio\SFX\gd-select2.wav");
            _select2.Open(new Uri(path));
            _select2.Volume = 1;
            _select2.Position = TimeSpan.MaxValue;

            path = Path.GetFullPath(@"Audio\SFX\gd-back.wav");
            _back.Open(new Uri(path));
            _back.Volume = 1;
            _back.Position = TimeSpan.MaxValue;

            path = Path.GetFullPath(@"Audio\Music\gd-bg.wav");
            _music.Open(new Uri(path));
            _music.Volume = 0.5;
            _music.MediaEnded += (object? sender, EventArgs e) => {
                _music.Position = TimeSpan.Zero;
                _music.Play();
            };
        }


        #region SFX
        private static MediaPlayer _select1 = new MediaPlayer();
        public static void PlaySelect1() {
            _select1.Position = TimeSpan.Zero;
            _select1.Play();
        }

        private static MediaPlayer _select2 = new MediaPlayer();
        public static void PlaySelect2() {
            _select2.Position = TimeSpan.Zero;
            _select2.Play();
        }

        private static MediaPlayer _back = new MediaPlayer();
        public static void PlayBack() {
            _back.Position = TimeSpan.Zero;
            _back.Play();
        }
        #endregion


        #region Music
        private static MediaPlayer _music = new MediaPlayer();
        public static void StartMusic(object? sender = null, EventArgs? e = null) {
            _music.Play();
        }
        public static void StopMusic() {
            _music.Stop();
        }
        #endregion


        #region Muting
        private static bool _sfxMuted;
        public static bool SfxMuted { get { return _sfxMuted; } set { _sfxMuted = value; RefreshAllSfxMute(); } }
        public static void ToggleSfxMute() {
            SfxMuted = !SfxMuted;
        }
        private static void RefreshAllSfxMute() {
            _select1.IsMuted = _sfxMuted;
            _select2.IsMuted = _sfxMuted;
            _back.IsMuted = _sfxMuted;
        }

        public static bool MusicMuted { get { return _music.IsMuted; } set { _music.IsMuted = value; } }
        public static void ToggleMusicMute() {
            MusicMuted = !MusicMuted;
        }
        #endregion
    }
}
