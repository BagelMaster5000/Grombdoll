using Grombdoll.Models.Systems;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Grombdoll.Models {
    public class DressUpModel {
        private bool currentGrombitSaved = false;

        public DressUpModel() {
            ResetCustomizations();
        }

        private int curBase;
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

            currentGrombitSaved = false;
        }

        private int curEyes;
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

            currentGrombitSaved = false;
        }

        private int curMouth;
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

            currentGrombitSaved = false;
        }

        private int curOutfit;
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

            currentGrombitSaved = false;
        }

        private int curShoes;
        public string CurShoesImagePath { get { return shoesImagePaths[curShoes]; } }
        private string[] shoesImagePaths = {
            @"..\Graphics\Shoes\Red.png",
            @"..\Graphics\Shoes\EasyToClean.png",
            @"..\Graphics\Shoes\PennySlippers.png",
            @"..\Graphics\Shoes\TylerSneaks.png",
        };
        public void IncrementShoesSelection() {
            curShoes = (curShoes + 1) % shoesImagePaths.Length;

            currentGrombitSaved = false;
        }

        private int curAccessory;
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

            currentGrombitSaved = false;
        }

        private int curBackground;
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

            currentGrombitSaved = false;
        }

        public void ResetCustomizations() {
            curBase = 0;
            curEyes = 0;
            curMouth = 0;
            curOutfit = 0;
            curShoes = 0;
            curAccessory = 0;
            curBackground = 0;

            currentGrombitSaved = false;
        }


        public void CopyGrombitToClipboardAndSaveLocally(Visual currentGrombitVisual) {
            RenderTargetBitmap bmpCopied = CopyGrombitToClipboard(currentGrombitVisual);

            if (!currentGrombitSaved && GlobalVariables.LocalStorageSaving) {
                GrombitLocalSaveSystem.SaveGrombitToLocalStorage(bmpCopied);
            }

            currentGrombitSaved = true;
        }

        private static RenderTargetBitmap CopyGrombitToClipboard(Visual currentGrombitVisual) {
            double width, height;
            if (GlobalVariables.CrunchMode) {
                width = 58;
                height = 68;
            }
            else {
                width = 580;
                height = 680;
            }
            RenderTargetBitmap bmpCopied = new RenderTargetBitmap((int)Math.Round(width), (int)Math.Round(height), 96, 96, PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen()) {
                VisualBrush vb = new VisualBrush(currentGrombitVisual);
                dc.DrawRectangle(vb, null, new Rect(new Point(), new Size(width, height)));
            }
            bmpCopied.Render(dv);
            Clipboard.SetImage(bmpCopied);
            return bmpCopied;
        }


    }
}
