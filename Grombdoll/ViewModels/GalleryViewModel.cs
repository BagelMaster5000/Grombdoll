using Grombdoll.Models;
using System;
using System.Windows.Media;
using static Grombdoll.Models.GalleryModel;

namespace Grombdoll.ViewModels {
    public class GalleryViewModel : ViewModelBase {
        private readonly GalleryModel _galleryModel;
        public GrombitGridImage[] AllGrombitImages => _galleryModel.AllGrombitImages;

        public Func<bool> ShowDressUpView;

        public GalleryViewModel(Func<bool> showDressUpView) {
            _galleryModel = new GalleryModel();

            ShowDressUpView = () => {
                //AudioSystem.PlayPuzzleStart();
                return showDressUpView();
            };
        }
    }
}
