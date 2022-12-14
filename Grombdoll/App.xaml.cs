using Grombdoll.Models.Systems;
using Grombdoll.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Grombdoll {
    public partial class App : Application {
        public App() { }

        protected override void OnStartup(StartupEventArgs e) {
            AudioSystem.InitializeMediaPlayers();

            MainWindow = new MainWindow() {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
