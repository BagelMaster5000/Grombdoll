﻿using System;

namespace Grombdoll.ViewModels {
    public class DressUpViewModel : ViewModelBase {
        public Func<bool> ShowTitleView;
        public Func<bool> ShowGalleryView;
        public Func<bool> ShowCreditsView;

        private int curBase = 0;
        public string CurBaseImagePath { get { return baseImagePaths[curBase]; } }
        private string[] baseImagePaths = {
            @"..\Graphics\Base\Standard.png",
            @"..\Graphics\Base\Desaturated.png",
            @"..\Graphics\Base\Eternal.png",
            @"..\Graphics\Base\Spoopy.png",
        };
        public void IncrementBaseSelection() {
            curBase = (curBase + 1) % baseImagePaths.Length;
            OnPropertyChanged(nameof(CurBaseImagePath));
        }

        private int curEyes = 0;
        public string CurEyesImagePath { get { return eyesImagePaths[curEyes]; } }
        private string[] eyesImagePaths = {
            @"..\Graphics\Eyes\Standard.png",
            @"..\Graphics\Eyes\Happy.png",
            @"..\Graphics\Eyes\Pretty.png",
            @"..\Graphics\Eyes\Picross.png",
        };
        public void IncrementEyesSelection() {
            curEyes = (curEyes + 1) % eyesImagePaths.Length;
            OnPropertyChanged(nameof(CurEyesImagePath));
        }

        private int curMouth = 0;
        public string CurMouthImagePath { get { return mouthImagePaths[curMouth]; } }
        private string[] mouthImagePaths = {
            @"..\Graphics\Mouths\Standard.png",
            @"..\Graphics\Mouths\n.png",
            @"..\Graphics\Mouths\O.png",
            @"..\Graphics\Mouths\U.png",
            @"..\Graphics\Mouths\V.png",
            @"..\Graphics\Mouths\w.png",
        };
        public void IncrementMouthSelection() {
            curMouth = (curMouth + 1) % mouthImagePaths.Length;
            OnPropertyChanged(nameof(CurMouthImagePath));
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
        }

        private int curAccessory = 0;
        public string CurAccessoryImagePath { get { return accessoryImagePaths[curAccessory]; } }
        private string[] accessoryImagePaths = {
            @"",
            @"..\Graphics\Accessories\CandyBucket.png",
            @"..\Graphics\Accessories\ForkKnife.png",
            @"..\Graphics\Accessories\Bagel.png",
            @"..\Graphics\Accessories\Glube.png",
            @"..\Graphics\Accessories\GrombitEternal.png",
            @"..\Graphics\Accessories\Jellycat.png",
        };
        public void IncrementAccessorySelection() {
            curAccessory = (curAccessory + 1) % accessoryImagePaths.Length;
            OnPropertyChanged(nameof(CurAccessoryImagePath));
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
