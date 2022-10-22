using Grombdoll.Models.Systems;
using System;

namespace Grombdoll.ViewModels {
    public class TitleViewModel : ViewModelBase {
        public Func<bool> ShowDressUpView;

        public string Version => GlobalVariables.VERSION;

        public TitleViewModel(Func<bool> showDressUpView) {
            AudioSystem.StartMusic();

            ShowDressUpView = () => {
                AudioSystem.PlaySelect2();
                return showDressUpView();
            };
        }
    }
}
