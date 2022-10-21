using Grombdoll.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Grombdoll.Views {
    public partial class GalleryView : UserControl {
        GalleryViewModel _galleryViewModel;
        public GalleryView() {
            Loaded += OnLoaded;
            Unloaded += OnUnloaded;
            
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            _galleryViewModel = (GalleryViewModel)DataContext;
            MainViewModel.OnViewChanged += SetGridRowsAndColumns;

            SetGridRowsAndColumns();
        }
        private void OnUnloaded(object sender, RoutedEventArgs e) {
            MainViewModel.OnViewChanged -= SetGridRowsAndColumns;
        }

        // Buttons clicked
        private void BackButtonClicked(object sender, RoutedEventArgs e) => _galleryViewModel.ShowDressUpView();
        private void OpenGrombSaveFolder(object sender, RoutedEventArgs e) => _galleryViewModel.OpenGrombSaveFolder();

        private void SetGridRowsAndColumns() {
            int numPuzzles = _galleryViewModel.AllGrombitImages.Length;
            int numColumns = GlobalVariables.GALLERY_NUM_COLUMNS;
            int numRows = numPuzzles / numColumns;
            if (numPuzzles % numColumns != 0) {
                numRows++;
            }

            string xaml =
                @"<ItemsPanelTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>" +
                    "<Grid>" +
                        "<Grid.RowDefinitions>";
            for (int r = 0; r < numRows; r++) { xaml += @"<RowDefinition Height=""190"" />"; }
            xaml +=
                        "</Grid.RowDefinitions>" +
                        "<Grid.ColumnDefinitions>";
            for (int c = 0; c < numColumns; c++) { xaml += @"<ColumnDefinition Width=""190"" />"; }
            xaml +=
                        "</Grid.ColumnDefinitions>" +
                    "</Grid>" +
                "</ItemsPanelTemplate>";

            ItemsPanelTemplate itemsPanelTemplate = XamlReader.Parse(xaml) as ItemsPanelTemplate;

            GrombitsView.ItemsPanel = itemsPanelTemplate;
        }
    }
}
