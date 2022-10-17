using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace Grombdoll.ViewModels {
    public class MainViewModel : ViewModelBase {
        public ViewModelBase CurrentViewModel { get; set; }

        // Transitioning variables
        private Timer _transitionInTimer;
        public Action OnTransitionIn;
        public float TransitionInDuration = 0.45f;

        private Timer _transitionOutTimer;
        public Action OnTransitionOut;
        public float TransitionOutDuration = 0.5f;

        public Action OnTransitionFinished;
        private ViewModelBase queuedViewModel = null;

        public static Action OnViewChanged;

        #region Setup
        public MainViewModel() {
            InitializeTransitionTimer();

            ShowDressUpView();
        }

        private void InitializeTransitionTimer() {
            _transitionInTimer = new Timer(TransitionInDuration * 1000);
            _transitionInTimer.Elapsed += (object? sender, ElapsedEventArgs e) => {
                Application.Current.Dispatcher.Invoke(() => {
                    StartTransitioningOut();
                    ShowQueuedViewModel();
                });
            };
            _transitionInTimer.AutoReset = false;

            _transitionOutTimer = new Timer(TransitionOutDuration * 1000);
            _transitionOutTimer.Elapsed += (object? sender, ElapsedEventArgs e) => {
                Application.Current.Dispatcher.Invoke(() => {
                    FinishedTransitioning();
                });
            };
            _transitionOutTimer.AutoReset = false;
        }
        #endregion


        #region Transition
        private void StartTransitioningIn() {
            _transitionInTimer.Enabled = true;
            _transitionInTimer.Start();

            OnTransitionIn?.Invoke();
        }
        private void StartTransitioningOut() {
            _transitionOutTimer.Enabled = true;
            _transitionOutTimer.Start();

            OnTransitionOut?.Invoke();
        }
        private void FinishedTransitioning() {
            OnTransitionFinished?.Invoke();
        }

        private bool ShowOrQueueViewModel(ViewModelBase setViewModel) {
            if (CurrentViewModel == null) {
                CurrentViewModel = setViewModel;
                return false;
            }
            else {
                QueueViewModel(setViewModel);
                return true;
            }
        }
        private void ShowQueuedViewModel() {
            if (queuedViewModel == null) {
                throw new Exception("No queued view model for after transition");
            }

            CurrentViewModel = queuedViewModel;
            OnPropertyChanged(nameof(CurrentViewModel));

            OnViewChanged?.Invoke();
        }
        private void QueueViewModel(ViewModelBase setQueuedViewModel) {
            queuedViewModel = setQueuedViewModel;
        }
        #endregion

        #region Showing ViewModels
        public bool ShowTitleView() {
            TitleViewModel titleViewModel = new TitleViewModel(ShowDressUpView);
            bool viewModelWasQueued = ShowOrQueueViewModel(titleViewModel);

            if (viewModelWasQueued) {
                StartTransitioningIn();
            }

            return true;
        }

        public bool ShowDressUpView() {
            DressUpViewModel titleViewModel = new DressUpViewModel(ShowTitleView, ShowGalleryView, ShowCreditsView);
            bool viewModelWasQueued = ShowOrQueueViewModel(titleViewModel);

            if (viewModelWasQueued) {
                StartTransitioningIn();
            }

            return true;
        }

        public bool ShowGalleryView() {
            TitleViewModel titleViewModel = new TitleViewModel(ShowDressUpView);
            bool viewModelWasQueued = ShowOrQueueViewModel(titleViewModel);

            if (viewModelWasQueued) {
                StartTransitioningIn();
            }

            return true;
        }

        public bool ShowCreditsView() {
            CreditsViewModel creditsViewModel = new CreditsViewModel(ShowDressUpView);
            bool viewModelWasQueued = ShowOrQueueViewModel(creditsViewModel);

            if (viewModelWasQueued) {
                StartTransitioningIn();
            }

            return true;
        }

        public bool ShowSettingsView() {
            SettingsViewModel settingsViewModel = new SettingsViewModel(ShowDressUpView);
            bool viewModelWasQueued = ShowOrQueueViewModel(settingsViewModel);

            if (viewModelWasQueued) {
                StartTransitioningIn();
            }

            return true;
        }
        #endregion
    }
}
