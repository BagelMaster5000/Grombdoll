using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Grombdoll.Models.Systems
{
    public static class GrombitLocalSaveSystem
    {
        public struct GrombitGridImage {
            public ImageSource GrombitImage { get; set; }
            public int Row { get; set; }
            public int Column { get; set; }
        }



        // Saving grombit
        public static void SaveGrombitToLocalStorage(RenderTargetBitmap bmpCopied) {
            CreateGrombitSaveFolderIfMissing();

            int curGrombIndex = GetNextAvailableSavedGrombitIndex();
            string curGrombFileName = GlobalVariables.GROMBIT_SAVE_NAME + curGrombIndex;

            string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
            string filePath = String.Format(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME + "\\" + curGrombFileName + ".bmp");

            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmpCopied));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
                encoder.Save(stream);
        }
        private static int GetNextAvailableSavedGrombitIndex() {
            string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
            DirectoryInfo d = new DirectoryInfo(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME);

            // Delete files with incorrect naming convention
            FileInfo[] files = d.GetFiles("*.bmp");
            for (int i = 0; i < files.Length; i++) {
                string fName = Path.GetFileNameWithoutExtension(files[i].Name);
                if (!int.TryParse(fName.AsSpan(GlobalVariables.GROMBIT_SAVE_NAME.Length), out int dummy)) {
                    File.Delete(files[i].FullName);
                }
            }

            // Get array of ints
            files = d.GetFiles("*.bmp");
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

        // Getting array of all grombit images in save folder
        public static GrombitGridImage[] GetAllGrombitImagesInSaveFolder() {
            CreateGrombitSaveFolderIfMissing();

            DirectoryInfo d = GetSaveFileDirectoryInfo();
            FileInfo[] files = d.GetFiles("*.bmp");
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


        // Opening grombit save folder
        public static void OpenGrombSaveFolder() {
            CreateGrombitSaveFolderIfMissing();

            DirectoryInfo d = GetSaveFileDirectoryInfo();
            Process.Start("explorer.exe", d.FullName);
        }


        // Helpers
        private static void CreateGrombitSaveFolderIfMissing() {
            string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
            Directory.CreateDirectory(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME);
        }

        public static DirectoryInfo GetSaveFileDirectoryInfo() {
            string appStartPath = Path.GetDirectoryName(Environment.ProcessPath);
            DirectoryInfo directoryInfo = new DirectoryInfo(appStartPath + "\\" + GlobalVariables.GROMBIT_SAVE_FOLDER_NAME);
            return directoryInfo;
        }
    }
}
