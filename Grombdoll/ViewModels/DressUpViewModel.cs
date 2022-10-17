using System;

namespace Grombdoll.ViewModels {
    public class DressUpViewModel : ViewModelBase {
        public Func<bool> ShowTitleView;
        public Func<bool> ShowGalleryView;
        public Func<bool> ShowCreditsView;

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
