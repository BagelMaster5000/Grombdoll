using Grombdoll.Models.Systems;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Grombdoll.Models {
    public class GalleryModel {
        public GrombitLocalSaveSystem.GrombitGridImage[] AllGrombitImages;

        public GalleryModel() {
            GenerateGrombitImages();
        }

        public void GenerateGrombitImages() {
            AllGrombitImages = GrombitLocalSaveSystem.GetAllGrombitImagesInSaveFolder();
        }

        public void OpenGrombSaveFolder() {
            GrombitLocalSaveSystem.OpenGrombSaveFolder();
        }
    }
}
