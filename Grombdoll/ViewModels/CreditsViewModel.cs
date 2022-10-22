using Grombdoll.Models.Systems;
using System;

namespace Grombdoll.ViewModels {
    public class CreditsViewModel : ViewModelBase {
        public Func<bool> ShowDressUpView;

        public CreditsViewModel(Func<bool> showDressUpView) {
            ShowDressUpView = () => {
                AudioSystem.PlayBack();
                return showDressUpView();
            };
        }
    }
}
