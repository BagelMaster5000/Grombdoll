using Grombdoll.ViewModels;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Grombdoll.Views {
    public partial class DressUpView : UserControl {
        DressUpViewModel _dressUpViewModel;

        private float slideInTime = 0.4f;
        private Duration slideInDuration;
        private DoubleAnimation slideInAnimation;
        private IEasingFunction slideInEasingFunction;

        public DressUpView() {
            Loaded += OnLoaded;

            InitializeComponent();
        }
        private void OnLoaded(object sender, RoutedEventArgs e) {
            _dressUpViewModel = (DressUpViewModel)DataContext;

            slideInDuration = new Duration(TimeSpan.FromSeconds(slideInTime));
            slideInAnimation = new DoubleAnimation(75, 0, slideInDuration);
            slideInEasingFunction = new BackEase() { EasingMode = EasingMode.EaseOut };
            slideInAnimation.EasingFunction = slideInEasingFunction;

            _dressUpViewModel.OnCustomizationChanged += PlayCustomizationChangedSound;
            _dressUpViewModel.OnBaseChanged += PlayBaseSlideInAnimation;
            _dressUpViewModel.OnEyesChanged += PlayEyesSlideInAnimation;
            _dressUpViewModel.OnMouthChanged += PlayMouthSlideInAnimation;
            _dressUpViewModel.OnOutfitChanged += PlayOutfitSlideInAnimation;
            _dressUpViewModel.OnShoesChanged += PlayShoesSlideInAnimation;
            _dressUpViewModel.OnAccessoryChanged += PlayAccessorySlideInAnimation;
            _dressUpViewModel.OnBackgroundChanged += PlayBackgroundSlideInAnimation;
            _dressUpViewModel.OnReset += PlayResetAnimation;
        }

        // Buttons clicked
        private void BaseButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementBaseSelection();
        private void EyesButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementEyesSelection();
        private void MouthButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementMouthSelection();
        private void OutfitButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementOutfitSelection();
        private void ShoesButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementShoesSelection();
        private void AccessoryButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementAccessorySelection();
        private void BackgroundButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.IncrementBackgroundSelection();
        private void ResetButtonClicked(object sender, RoutedEventArgs e) => _dressUpViewModel.ResetCustomizations();
        private void SaveButtonClicked(object sender, RoutedEventArgs e) {
            double width = 50;
            double height = 100;
            RenderTargetBitmap bmpCopied = new RenderTargetBitmap((int)Math.Round(width), (int)Math.Round(height), 96, 96, PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen()) {
                VisualBrush vb = new VisualBrush(AllLayers);
                dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(width, height)));
            }
            bmpCopied.Render(dv);
            Clipboard.SetImage(bmpCopied);


            String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string filePath = String.Format(appStartPath + "\\" + "TestGrombSave.bmp", "SavingTest");

            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpCopied));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
        }





        private void PlayBaseSlideInAnimation() => Base.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayEyesSlideInAnimation() => Eyes.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayMouthSlideInAnimation() => Mouth.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayOutfitSlideInAnimation() => Outfit.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayShoesSlideInAnimation() => Shoes.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayAccessorySlideInAnimation() => Accessory.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);
        private void PlayBackgroundSlideInAnimation() => Background.RenderTransform.BeginAnimation(TranslateTransform.XProperty, slideInAnimation);

        private void PlayResetAnimation() {
            DoubleAnimation scaleAnimation = new DoubleAnimation(1.1, 1, slideInDuration);
            scaleAnimation.EasingFunction = new QuadraticEase() { EasingMode = EasingMode.EaseOut };
            AllLayers.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleAnimation);
            AllLayers.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnimation);
        }

        private void PlayCustomizationChangedSound() { }
    }
}
