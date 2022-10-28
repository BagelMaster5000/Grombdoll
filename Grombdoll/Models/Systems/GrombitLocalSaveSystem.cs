using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Grombdoll.Models.Systems {
    public static class GrombitLocalSaveSystem {
        public struct GrombitGridImage {
            public ImageSource GrombitImage { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
        }

        private static string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
        private static DirectoryInfo grombitSaveDirectory = new DirectoryInfo(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME);

        public static void SaveGrombitToLocalStorage(RenderTargetBitmap bmpCopied) {
            CreateGrombitSaveFolderIfMissing();

            int curGrombIndex = GetNextAvailableSavedGrombitIndex();
            string curGrombFileName = GlobalVariables.GROMBIT_SAVE_NAME + curGrombIndex;

            string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
            string filePath = String.Format(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME + "\\" + curGrombFileName + ".png");

            MemoryStream stream = new MemoryStream();
            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpCopied));
            encoder.Save(stream);
            Bitmap bitmap = new Bitmap(stream);
            bitmap.Save(filePath, ImageFormat.Png);
        }

        private static int GetNextAvailableSavedGrombitIndex() {
            // Delete files with incorrect naming convention
            DeleteFilesInSaveDirectoryWithIncorrectNamingConvention();

            // Get array of ints
            FileInfo[] files = grombitSaveDirectory.GetFiles("*.png");
            int[] fileIndexes = new int[files.Length];
            for (int i = 0; i < files.Length; i++) {
                string fName = Path.GetFileNameWithoutExtension(files[i].Name);
                int fIndex = int.Parse(fName.AsSpan(GlobalVariables.GROMBIT_SAVE_NAME.Length));
                fileIndexes[i] = fIndex;
            }
            Array.Sort(fileIndexes);

            // Get next available index for save file
            int nextAvailableIndex = -1;
            for (int i = 0; i < fileIndexes.Length; i++) {
                if (fileIndexes[i] != i + 1) {
                    nextAvailableIndex = i + 1;
                    break;
                }
            }
            if (nextAvailableIndex == -1) {
                nextAvailableIndex = fileIndexes.Length + 1;
            }

            return nextAvailableIndex;
        }


        public static GrombitGridImage[] GetAllGrombitImagesInSaveFolder() {
            CreateGrombitSaveFolderIfMissing();

            FileInfo[] files = grombitSaveDirectory.GetFiles("*.png");
            Array.Sort(files,
                delegate (FileInfo a, FileInfo b) {
                    string aName = Path.GetFileNameWithoutExtension(a.Name);
                    int aIndex = int.Parse(aName.AsSpan(GlobalVariables.GROMBIT_SAVE_NAME.Length));

                    string bName = Path.GetFileNameWithoutExtension(b.Name);
                    int bIndex = int.Parse(bName.AsSpan(GlobalVariables.GROMBIT_SAVE_NAME.Length));

                    return aIndex - bIndex;
                });
            GrombitGridImage[] _allGrombitImages = new GrombitGridImage[files.Length];
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

                    _allGrombitImages[i].GrombitImage = bitmapimage;
                    _allGrombitImages[i].Row = i / GlobalVariables.GALLERY_NUM_COLUMNS;
                    _allGrombitImages[i].Column = i % GlobalVariables.GALLERY_NUM_COLUMNS;
                }
            }

            return _allGrombitImages;
        }


        public static void OpenGrombSaveFolder() {
            CreateGrombitSaveFolderIfMissing();

            Process.Start("explorer.exe", grombitSaveDirectory.FullName);
        }

        public static void NukeSavedGrombits() {
            foreach (FileInfo file in grombitSaveDirectory.GetFiles()) {
                file.Delete();
            }
            foreach (DirectoryInfo dir in grombitSaveDirectory.GetDirectories()) {
                dir.Delete(true);
            }
        }

        // Helpers
        private static void DeleteFilesInSaveDirectoryWithIncorrectNamingConvention() {
            FileInfo[] files = grombitSaveDirectory.GetFiles("*.bmp");
            for (int i = 0; i < files.Length; i++) {
                string fName = Path.GetFileNameWithoutExtension(files[i].Name);
                if (!int.TryParse(fName.AsSpan(GlobalVariables.GROMBIT_SAVE_NAME.Length), out int dummy)) {
                    File.Delete(files[i].FullName);
                }
            }
        }

        private static void CreateGrombitSaveFolderIfMissing() {
            Directory.CreateDirectory(grombitSaveDirectory.FullName);
        }
    }
}
