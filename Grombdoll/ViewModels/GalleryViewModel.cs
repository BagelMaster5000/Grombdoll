using Grombdoll.Models;
using Grombdoll.Models.Systems;
using System;
using static Grombdoll.Models.GalleryModel;

namespace Grombdoll.ViewModels {
    public class GalleryViewModel : ViewModelBase {
        private readonly GalleryModel _galleryModel;
        public GrombitGridImage[] AllGrombitImages => _galleryModel.AllGrombitImages;

        public Func<bool> ShowDressUpView;

        public GalleryViewModel(Func<bool> showDressUpView) {
            _galleryModel = new GalleryModel();

            ShowDressUpView = () => {
                AudioSystem.PlayBack();
                return showDressUpView();
            };
        }

        public void OpenGrombSaveFolder() {
            _galleryModel.OpenGrombSaveFolder();

            AudioSystem.PlaySelect2();
        }
    }
}
