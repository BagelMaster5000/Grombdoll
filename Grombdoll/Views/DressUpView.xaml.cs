using Grombdoll.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Grombdoll.Views {
    public partial class DressUpView : UserControl {
        DressUpViewModel _dressUpViewModel;
        public DressUpView() {
            Loaded += OnLoaded;

            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs e) { _dressUpViewModel = (DressUpViewModel)DataContext; }

        private void BaseButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementBaseSelection();
            PlayAccessoryIncrementSFX();
        }
        private void EyesButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementEyesSelection();
            PlayAccessoryIncrementSFX();
        }
        private void MouthButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementMouthSelection();
            PlayAccessoryIncrementSFX();
        }
        private void OutfitButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementOutfitSelection();
            PlayAccessoryIncrementSFX();
        }
        private void ShoesButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementShoesSelection();
            PlayAccessoryIncrementSFX();
        }
        private void AccessoryButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementAccessorySelection();
            PlayAccessoryIncrementSFX();
        }
        private void BackgroundButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.IncrementBackgroundSelection();
            PlayAccessoryIncrementSFX();
        }
        private void ResetButtonClicked(object sender, RoutedEventArgs e) {
            _dressUpViewModel.ResetCustomizations();
            PlayAccessoryIncrementSFX();
        }

        private void PlayAccessoryIncrementSFX() {

        }
    }
}
