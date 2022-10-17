using System;

namespace Grombdoll.ViewModels {
    public class GalleryViewModel : ViewModelBase {
        public Func<bool> ShowDressUpView;

        public GalleryViewModel(Func<bool> showDressUpView) {
            ShowDressUpView = () => {
                //AudioSystem.PlayPuzzleStart();
                return showDressUpView();
            };
        }
    }
}
