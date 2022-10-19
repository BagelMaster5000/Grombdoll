using System;

namespace Grombdoll.ViewModels {
    public class DressUpViewModel : ViewModelBase {
        public Func<bool> ShowTitleView;
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

        private int curBase = 0;
        public string CurBaseImagePath { get { return baseImagePaths[curBase]; } }
        private string[] baseImagePaths = {
            @"..\Graphics\Base\Standard.png",
            @"..\Graphics\Base\Desaturated.png",
            @"..\Graphics\Base\Cyan.png",
            @"..\Graphics\Base\Magenta.png",
            @"..\Graphics\Base\Yellow.png",
            @"..\Graphics\Base\Eternal.png",
            @"..\Graphics\Base\Spoopy.png",
        };
        public void IncrementBaseSelection() {
            curBase = (curBase + 1) % baseImagePaths.Length;
            OnPropertyChanged(nameof(CurBaseImagePath));

            OnBaseChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curEyes = 0;
        public string CurEyesImagePath { get { return eyesImagePaths[curEyes]; } }
        private string[] eyesImagePaths = {
            @"..\Graphics\Eyes\Standard.png",
            @"..\Graphics\Eyes\Happy.png",
            @"..\Graphics\Eyes\OhNo.png",
            @"..\Graphics\Eyes\Pretty.png",
            @"..\Graphics\Eyes\Smug.png",
            @"..\Graphics\Eyes\Squint.png",
            @"..\Graphics\Eyes\X.png",
            @"..\Graphics\Eyes\Picross.png",
        };
        public void IncrementEyesSelection() {
            curEyes = (curEyes + 1) % eyesImagePaths.Length;
            OnPropertyChanged(nameof(CurEyesImagePath));

            OnEyesChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curMouth = 0;
        public string CurMouthImagePath { get { return mouthImagePaths[curMouth]; } }
        private string[] mouthImagePaths = {
            @"..\Graphics\Mouths\Standard.png",
            @"..\Graphics\Mouths\n.png",
            @"..\Graphics\Mouths\O.png",
            @"..\Graphics\Mouths\P.png",
            @"..\Graphics\Mouths\U.png",
            @"..\Graphics\Mouths\V.png",
            @"..\Graphics\Mouths\GameDev.png",
            @"..\Graphics\Mouths\A.png",
            @"..\Graphics\Mouths\w.png",
        };
        public void IncrementMouthSelection() {
            curMouth = (curMouth + 1) % mouthImagePaths.Length;
            OnPropertyChanged(nameof(CurMouthImagePath));

            OnMouthChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curOutfit = 0;
        public string CurOutfitImagePath { get { return outfitImagePaths[curOutfit]; } }
        private string[] outfitImagePaths = {
            @"",
            @"..\Graphics\Outfits\Shelly.png",
            @"..\Graphics\Outfits\TopGun.png",
            @"..\Graphics\Outfits\RevivalJam.png",
            @"..\Graphics\Outfits\NiteVision.png",
            @"..\Graphics\Outfits\HexDream.png",
            @"..\Graphics\Outfits\HexFish.png",
            @"..\Graphics\Outfits\HexGoodVibes.png",
            @"..\Graphics\Outfits\HexTrash.png",
        };
        public void IncrementOutfitSelection() {
            curOutfit = (curOutfit + 1) % outfitImagePaths.Length;
            OnPropertyChanged(nameof(CurOutfitImagePath));

            OnOutfitChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curShoes = 0;
        public string CurShoesImagePath { get { return shoesImagePaths[curShoes]; } }
        private string[] shoesImagePaths = {
            @"..\Graphics\Shoes\Red.png",
            @"..\Graphics\Shoes\EasyToClean.png",
            @"..\Graphics\Shoes\PennySlippers.png",
            @"..\Graphics\Shoes\TylerSneaks.png",
        };
        public void IncrementShoesSelection() {
            curShoes = (curShoes + 1) % shoesImagePaths.Length;
            OnPropertyChanged(nameof(CurShoesImagePath));

            OnShoesChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curAccessory = 0;
        public string CurAccessoryImagePath { get { return accessoryImagePaths[curAccessory]; } }
        private string[] accessoryImagePaths = {
            @"",
            @"..\Graphics\Accessories\CandyBucket.png",
            @"..\Graphics\Accessories\ForkKnife.png",
            @"..\Graphics\Accessories\Bagel.png",
            @"..\Graphics\Accessories\Pin.png",
            @"..\Graphics\Accessories\Glube.png",
            @"..\Graphics\Accessories\GrombitEternal.png",
            @"..\Graphics\Accessories\Jellycat.png",
        };
        public void IncrementAccessorySelection() {
            curAccessory = (curAccessory + 1) % accessoryImagePaths.Length;
            OnPropertyChanged(nameof(CurAccessoryImagePath));

            OnAccessoryChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        private int curBackground = 0;
        public string CurBackgroundImagePath { get { return backgroundImagePaths[curBackground]; } }
        private string[] backgroundImagePaths = {
            @"..\Graphics\Backgrounds\Standard.png",
            @"..\Graphics\Backgrounds\Lemons.png",
            @"..\Graphics\Backgrounds\TinyCon.png",
            @"..\Graphics\Backgrounds\Costco.png",
            @"..\Graphics\Backgrounds\GunTable.png",
        };
        public void IncrementBackgroundSelection() {
            curBackground = (curBackground + 1) % backgroundImagePaths.Length;
            OnPropertyChanged(nameof(CurBackgroundImagePath));

            OnBackgroundChanged?.Invoke();
            OnCustomizationChanged?.Invoke();
        }

        public void ResetCustomizations() {
            curBase = 0;
            OnPropertyChanged(nameof(CurBaseImagePath));

            curEyes = 0;
            OnPropertyChanged(nameof(CurEyesImagePath));

            curMouth = 0;
            OnPropertyChanged(nameof(CurMouthImagePath));

            curOutfit = 0;
            OnPropertyChanged(nameof(CurOutfitImagePath));

            curShoes = 0;
            OnPropertyChanged(nameof(CurShoesImagePath));

            curAccessory = 0;
            OnPropertyChanged(nameof(CurAccessoryImagePath));

            curBackground = 0;
            OnPropertyChanged(nameof(CurBackgroundImagePath));

            OnReset?.Invoke();
        }

        public DressUpViewModel(Func<bool> showTitleView, Func<bool> showGalleryView, Func<bool> showCreditsView) {
            ShowTitleView = () => {
                return showTitleView();
            };
            ShowGalleryView = () => {
                return showGalleryView();
            };
            ShowCreditsView = () => {
                return showCreditsView();
            };
        }
    }
}
