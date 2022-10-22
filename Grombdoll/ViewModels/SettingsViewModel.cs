using Grombdoll.Models.Systems;
using System;

namespace Grombdoll.ViewModels {
    public class SettingsViewModel : ViewModelBase {
        public Func<bool> ShowDressUpView;

        public SettingsViewModel(Func<bool> showDressUpView) {
            ShowDressUpView = () => {
                AudioSystem.PlayBack();
                return showDressUpView();
            };
        }

        public bool SfxMuted { get { return AudioSystem.SfxMuted; } }
        public void ToggleSfxMute() {
            AudioSystem.ToggleSfxMute();

            AudioSystem.PlaySelect1();
        }

        public bool MusicMuted { get { return AudioSystem.MusicMuted; } }
        public void ToggleMusicMute() {
            AudioSystem.ToggleMusicMute();

            AudioSystem.PlaySelect1();
        }

        public bool CrunchModeActive { get { return GlobalVariables.CrunchMode; } }
        public void ToggleCrunchMode() {
            GlobalVariables.CrunchMode = !GlobalVariables.CrunchMode;

            AudioSystem.PlaySelect1();
        }

        public bool LocalStorageSavingActive { get { return GlobalVariables.LocalStorageSaving; } }
        public void ToggleLocalStorageSaving() {
            GlobalVariables.LocalStorageSaving = !GlobalVariables.LocalStorageSaving;

            AudioSystem.PlaySelect1();
        }
    }
}
