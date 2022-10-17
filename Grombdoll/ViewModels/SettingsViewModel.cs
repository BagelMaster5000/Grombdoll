using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grombdoll.ViewModels {
    public class SettingsViewModel : ViewModelBase {
        public Func<bool> ShowDressUpView;

        public SettingsViewModel(Func<bool> showDressUpView) {
            ShowDressUpView = () => {
                //AudioSystem.PlayPuzzleStart();
                return showDressUpView();
            };
        }
    }
}
