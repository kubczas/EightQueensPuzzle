using System.Threading.Tasks;
using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.Pawns;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Timer;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Unity;
using WpfUtilities;

namespace EightQueensPuzzle.ViewModels
{
    public class GameViewModel : ViewModelBase, IObserver, IGameViewModel
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private readonly IChessboard _chessboard;
        private readonly ITimerServiceManager _timerServiceManager;
        private TimerServiceBase _timerService;
        private bool _isGameStarted;
        private int _gameTime;
        private int _numberOfLeftPawns;
        private int _numberOfMistakes;
        private int _timeLimit = int.MaxValue;
        private int _mistakesLimit = int.MaxValue;

        public GameViewModel(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard) : base(settingsService)
        {
            _dialogCoordinator = dialogCoordinator;
            _chessboard = chessboard;
            LoadGameSettings();
            PlayGameCommand = new RelayCommand(PlayGame);
            RestartGameCommand = new RelayCommand(RestartGame);
            _timerServiceManager = UnityService.Instance.Get().Resolve<ITimerServiceManager>();
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

        public void Update()
        {
            Timer = _timerService.TimerValue;
        }

        private void InitTimer(ITimerServiceManager timerServiceManager)
        {
            if (timerServiceManager != null)
                _timerService = timerServiceManager.GetTimer(GameSettings.GameType.Timer, 100);
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
                _timeLimit = WinAsSoonAsPossible.MaxTime;
            }
            if (DoNotMakeMistakes == null) return;

            IsTipsEnabled = DoNotMakeMistakes.IsTipsEnabled;
            _mistakesLimit = DoNotMakeMistakes.MaxMistakes;
        }

        private void VerifyIfPlayerWonGame()
        {
            if (_numberOfLeftPawns == 0)
                _dialogCoordinator.ShowMessageAsync(this, "Congratulations", "You won game !!!");
        }

        private void VerifyIfPlayerLoseGame()
        {
            if (!_isGameStarted) return;

            if (!_timerService.IsCountingFinished && _timeLimit != Timer && _mistakesLimit >= NumberOfMistakes)
                return;

            _dialogCoordinator.ShowMessageAsync(this, "Lose", "You lose game!!!");
            _isGameStarted = false;
            _timerService.Reset();
        }

        private void PlayGame(object obj)
        {
            if (_isGameStarted) return;

            LoadGameSettings();
            InitTimer(_timerServiceManager);
            ChessboardField.IsReadonly = false;
            _isGameStarted = true;
        }

        private async void RestartGame(object obj)
        {
            Task<MessageDialogResult> progressDialogController =_dialogCoordinator.ShowMessageAsync(this, "Restart", "Restart game...");
            LoadGameSettings();
            _chessboard.ClearChessboard();
            ChessboardField.IsReadonly = true;
            _timerService?.Reset();
            _isGameStarted = false;
            NumberOfMistakes = 0;
            await progressDialogController;
        }
    }
}
