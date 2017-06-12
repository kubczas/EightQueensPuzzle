using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.Pawns;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Timer;
using EightQueensPuzzle.Views;
using MahApps.Metro.Controls.Dialogs;
using WpfUtilities;

namespace EightQueensPuzzle.ViewModels
{
    public class GameViewModel : ViewModelBase, IObserver, IGameViewModel
    {
        private TimerServiceBase _timerService;
        private bool _isGameStarted;
        private int _gameTime;
        private int _numberOfLeftPawns;
        private int _numberOfMistakes;

        public GameViewModel(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard, ITimerServiceManager timerServiceManager) : base(settingsService, dialogCoordinator,chessboard)
        {
            LoadGameSettings();
            InitTimer(timerServiceManager);
            PlayGameCommand = new RelayCommand(PlayGame);
            RestartGameCommand = new RelayCommand(RestetGame);
            DisplayInfoCommand = new RelayCommand(DisplayInfo);
        }

        private void DisplayInfo(object obj)
        {
            var infoWindow = new InfoWindow();
            infoWindow.Show();
        }

        public RelayCommand PlayGameCommand { get; set; }

        public RelayCommand RestartGameCommand { get; set; }

        public PawnBase SelectedPawn { get; private set; }

        public int Timer
        {
            get
            {
                return _gameTime;
            }
            set
            {
                _gameTime = value;
                OnPropertyChanged(nameof(Timer));
                VerifyIfPlayerLoseGame();
            }
        }

        public bool IsTipsEnabled { get; set; }

        public int NumberOfLeftPawns
        {
            get { return _numberOfLeftPawns; }
            set
            {
                _numberOfLeftPawns = value;
                OnPropertyChanged(nameof(NumberOfLeftPawns));
                VerifyIfPlayerWonGame();
            }
        }

        public int NumberOfMistakes
        {
            get { return _numberOfMistakes; }
            set
            {
                _numberOfMistakes = value;
                OnPropertyChanged(nameof(NumberOfMistakes));
                VerifyIfPlayerLoseGame();
            }
        }

        public RelayCommand DisplayInfoCommand { get; set; }

        public void Update()
        {
            Timer = _timerService.TimerValue;
        }

        private void InitTimer(ITimerServiceManager timerServiceManager)
        {
            if (timerServiceManager != null)
                _timerService = timerServiceManager.GetTimer(GameSettings.GameType.Timer, Timer);
            _timerService.InitTimer(this);
        }

        private void LoadGameSettings()
        {
            SelectedPawn = GameSettings.SelectedPawn;
            NumberOfLeftPawns = GameSettings.SelectedPawn.NumberOfPawns;
            if (TryToMakeIt != null)
            {
                Timer = TryToMakeIt.MaxTime;
                IsTipsEnabled = TryToMakeIt.IsTipsEnabled;
            }
            if (WinAsSoonAsPossible != null)
            {
                IsTipsEnabled = WinAsSoonAsPossible.IsTipsEnabled;
                TimeLimit = WinAsSoonAsPossible.MaxTime;
            }
            if (DoNotMakeMistakes == null) return;

            IsTipsEnabled = DoNotMakeMistakes.IsTipsEnabled;
            NumberOfPossibleMistakes = DoNotMakeMistakes.MaxMistakes;
        }

        private void VerifyIfPlayerWonGame()
        {
            if (_numberOfLeftPawns == 0)
                DialogCoordinator.ShowMessageAsync(this, "Congratulations", "You won game !!!");
        }

        private void VerifyIfPlayerLoseGame()
        {
            if (!_isGameStarted) return;

            if (!_timerService.IsCountingFinished && TimeLimit != Timer && NumberOfPossibleMistakes >= NumberOfMistakes)
                return;

            DialogCoordinator.ShowMessageAsync(this, "Lose", "You lose game!!!");
            _isGameStarted = false;
            _timerService.Reset();
        }

        private void PlayGame(object obj)
        {
            if (_isGameStarted) return;

            _timerService.Start();
            LoadGameSettings();

            ChessboardField.IsReadonly = false;
            _isGameStarted = true;
        }

        private async void RestetGame(object obj)
        {
            var progressDialogController =DialogCoordinator.ShowMessageAsync(this, "Restart", "Restart game...");
            LoadGameSettings();
            ResetSettings();
            await progressDialogController;
        }

        private void ResetSettings()
        {
            Chessboard.ClearChessboard();
            ChessboardField.IsReadonly = true;
            _timerService?.Reset();
            _isGameStarted = false;
            NumberOfMistakes = 0;
        }
    }
}
