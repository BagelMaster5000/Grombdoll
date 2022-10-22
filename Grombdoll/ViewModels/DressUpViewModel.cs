using Grombdoll.Models;
using Grombdoll.Models.Systems;
using System;
using System.Windows.Media;

namespace Grombdoll.ViewModels {
    public class DressUpViewModel : ViewModelBase {
        private readonly DressUpModel _dressUpModel;
        public string CurBaseImagePath => _dressUpModel.CurBaseImagePath;
        public string CurEyesImagePath => _dressUpModel.CurEyesImagePath;
        public string CurMouthImagePath => _dressUpModel.CurMouthImagePath;
        public string CurOutfitImagePath => _dressUpModel.CurOutfitImagePath;
        public string CurShoesImagePath => _dressUpModel.CurShoesImagePath;
        public string CurAccessoryImagePath => _dressUpModel.CurAccessoryImagePath;
        public string CurBackgroundImagePath => _dressUpModel.CurBackgroundImagePath;

        public Func<bool> ShowSettingsView;
        public Func<bool> ShowGalleryView;
        public Func<bool> ShowCreditsView;

        public Action OnCustomizationChanged;
        public Action OnBaseChanged;
        public Action OnEyesChanged;
        public Action OnMouthChanged;
        public Action OnOutfitChanged;
        public Action OnShoesChanged;
        public Action OnAccessoryChanged;
        public Action OnBackgroundChanged;
        public Action OnReset;

        public DressUpViewModel(Func<bool> showSettingsView, Func<bool> showGalleryView, Func<bool> showCreditsView) {
            _dressUpModel = new DressUpModel();

            ShowSettingsView = () => {
                AudioSystem.PlaySelect2();
                return showSettingsView();
            };
            ShowGalleryView = () => {
                AudioSystem.PlaySelect2();
                return showGalleryView();
            };
            ShowCreditsView = () => {
                AudioSystem.PlaySelect2();
                return showCreditsView();
            };
        }

        public void IncrementBaseSelection() {
            _dressUpModel.IncrementBaseSelection();

            OnPropertyChanged(nameof(CurBaseImagePath));

            OnBaseChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementEyesSelection() {
            _dressUpModel.IncrementEyesSelection();

            OnPropertyChanged(nameof(CurEyesImagePath));

            OnEyesChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementMouthSelection() {
            _dressUpModel.IncrementMouthSelection();

            OnPropertyChanged(nameof(CurMouthImagePath));

            OnMouthChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementOutfitSelection() {
            _dressUpModel.IncrementOutfitSelection();

            OnPropertyChanged(nameof(CurOutfitImagePath));

            OnOutfitChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementShoesSelection() {
            _dressUpModel.IncrementShoesSelection();

            OnPropertyChanged(nameof(CurShoesImagePath));

            OnShoesChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementAccessorySelection() {
            _dressUpModel.IncrementAccessorySelection();

            OnPropertyChanged(nameof(CurAccessoryImagePath));

            OnAccessoryChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void IncrementBackgroundSelection() {
            _dressUpModel.IncrementBackgroundSelection();

            OnPropertyChanged(nameof(CurBackgroundImagePath));

            OnBackgroundChanged?.Invoke();
            OnCustomizationChanged?.Invoke();

            AudioSystem.PlaySelect1();
        }

        public void ResetCustomizations() {
            _dressUpModel.ResetCustomizations();

            OnPropertyChanged(nameof(CurBaseImagePath));
            OnPropertyChanged(nameof(CurEyesImagePath));
            OnPropertyChanged(nameof(CurMouthImagePath));
            OnPropertyChanged(nameof(CurOutfitImagePath));
            OnPropertyChanged(nameof(CurShoesImagePath));
            OnPropertyChanged(nameof(CurAccessoryImagePath));
            OnPropertyChanged(nameof(CurBackgroundImagePath));

            OnReset?.Invoke();

            AudioSystem.PlayBack();
        }

        public void CopyGrombitToClipboardAndSaveLocally(Visual currentGrombitVisual) {
            _dressUpModel.CopyGrombitToClipboardAndSaveLocally(currentGrombitVisual);

            AudioSystem.PlaySelect1();
        }
    }
}
