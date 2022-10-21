using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Grombdoll.Models {
    public class GalleryModel {
        public struct GrombitGridImage {
            public ImageSource GrombitImage { get; set;  }
            public int Row { get; set; }
            public int Column { get; set; }
        }
        public GrombitGridImage[] AllGrombitImages;

        public GalleryModel() {
            GenerateGrombitImages();
        }

        public void GenerateGrombitImages() {
            string appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            DirectoryInfo d = new DirectoryInfo(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME);
            FileInfo[] files = d.GetFiles("*.bmp");
            AllGrombitImages = new GrombitGridImage[files.Length];
            for (int i = 0; i < files.Length; i++) {
                Bitmap bmp = new Bitmap(files[i].FullName);

                using (MemoryStream memory = new MemoryStream()) {
                    bmp.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;
                    BitmapImage bitmapimage = new BitmapImage();
                    bitmapimage.BeginInit();
                    bitmapimage.StreamSource = memory;
                    bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapimage.EndInit();

                    AllGrombitImages[i].GrombitImage = bitmapimage;
                    AllGrombitImages[i].Row = i / GlobalVariables.GALLERY_NUM_COLUMNS;
                    AllGrombitImages[i].Column = i % GlobalVariables.GALLERY_NUM_COLUMNS;
                }
            }
        }

    }
}
