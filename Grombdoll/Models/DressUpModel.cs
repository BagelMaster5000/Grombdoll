namespace Grombdoll.Models {
    public class DressUpModel {
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
        public void IncrementBaseSelection() => curBase = (curBase + 1) % baseImagePaths.Length;

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
        public void IncrementEyesSelection() => curEyes = (curEyes + 1) % eyesImagePaths.Length;

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
        public void IncrementMouthSelection() => curMouth = (curMouth + 1) % mouthImagePaths.Length;

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
        public void IncrementOutfitSelection() => curOutfit = (curOutfit + 1) % outfitImagePaths.Length;

        private int curShoes;
        public string CurShoesImagePath { get { return shoesImagePaths[curShoes]; } }
        private string[] shoesImagePaths = {
            @"..\Graphics\Shoes\Red.png",
            @"..\Graphics\Shoes\EasyToClean.png",
            @"..\Graphics\Shoes\PennySlippers.png",
            @"..\Graphics\Shoes\TylerSneaks.png",
        };
        public void IncrementShoesSelection() => curShoes = (curShoes + 1) % shoesImagePaths.Length;

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
        public void IncrementAccessorySelection() => curAccessory = (curAccessory + 1) % accessoryImagePaths.Length;

        private int curBackground;
        public string CurBackgroundImagePath { get { return backgroundImagePaths[curBackground]; } }
        private string[] backgroundImagePaths = {
            @"..\Graphics\Backgrounds\Standard.png",
            @"..\Graphics\Backgrounds\Lemons.png",
            @"..\Graphics\Backgrounds\TinyCon.png",
            @"..\Graphics\Backgrounds\Costco.png",
            @"..\Graphics\Backgrounds\GunTable.png",
        };
        public void IncrementBackgroundSelection() => curBackground = (curBackground + 1) % backgroundImagePaths.Length;

        public void ResetCustomizations() {
            curBase = 0;
            curEyes = 0;
            curMouth = 0;
            curOutfit = 0;
            curShoes = 0;
            curAccessory = 0;
            curBackground = 0;
        }
    }
}
