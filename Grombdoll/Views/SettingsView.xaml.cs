﻿using Grombdoll.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Grombdoll.Views {
    public partial class SettingsView : UserControl {
        SettingsViewModel _settingsViewModel;
        public SettingsView() {
            Loaded += OnLoaded;

            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs e) { _settingsViewModel = (SettingsViewModel)DataContext; }

        private void ShowPuzzleSelect(object sender, RoutedEventArgs e) {
            _settingsViewModel.ShowDressUpView();
        }

        // Buttons clicked
        private void BackButtonClicked(object sender, RoutedEventArgs e) => _settingsViewModel.ShowDressUpView();

        private void ToggleMusicMute(object sender, RoutedEventArgs e)  => _settingsViewModel.ToggleMusicMute();
        private void ToggleSfxMute(object sender, RoutedEventArgs e)  => _settingsViewModel.ToggleSfxMute();
    }
}
