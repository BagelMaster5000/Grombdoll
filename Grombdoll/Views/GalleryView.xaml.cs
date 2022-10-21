using Grombdoll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Grombdoll.Views {
    /// <summary>
    /// Interaction logic for GalleryView.xaml
    /// </summary>
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

        private void SetGridRowsAndColumns() {
            //int numPuzzles = _galleryViewModel.AllPuzzles.Count;
            //int numColumns = GlobalVariables.NumPuzzleSelectColumns;
            //int numRows = numPuzzles / numColumns;
            //if (numPuzzles % numColumns != 0) {
            //    numRows++;
            //}

            //string xaml =
            //    @"<ItemsPanelTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'>" +
            //        "<Grid>" +
            //            "<Grid.RowDefinitions>";
            //for (int r = 0; r < numRows; r++) { xaml += @"<RowDefinition Height=""190"" />"; }
            //xaml +=
            //            "</Grid.RowDefinitions>" +
            //            "<Grid.ColumnDefinitions>";
            //for (int c = 0; c < numColumns; c++) { xaml += @"<ColumnDefinition Width=""190"" />"; }
            //xaml +=
            //            "</Grid.ColumnDefinitions>" +
            //        "</Grid>" +
            //    "</ItemsPanelTemplate>";

            //ItemsPanelTemplate itemsPanelTemplate = XamlReader.Parse(xaml) as ItemsPanelTemplate;

            //PuzzleView.ItemsPanel = itemsPanelTemplate;
        }
    }
}
