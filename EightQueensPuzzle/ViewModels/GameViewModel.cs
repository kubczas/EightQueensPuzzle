using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.Pawns;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Timer;
using Microsoft.Practices.Unity;
using WpfUtilities;

namespace EightQueensPuzzle.ViewModels
{
    public class GameViewModel : ViewModelBase, IObserver, IGameViewModel
    {
        private string _gameTime = "0";
        private TimerServiceBase _timerServiceBase;
        private int _numberOfTips;
        private int _numberOfLeftPawns;
        private int _numberOfMistakes;
        private int _timeLimit;
        private int _mistakesLimit;

        public GameViewModel(ISettingsService settingsService) : base(settingsService)
        {
            LoadGameSettings();
            PlayGameCommand = new RelayCommand(PlayGame);
        }

        private void PlayGame(object obj)
        {
            ITimerServiceManager timerServiceManager = UnityService.Instance.Get().Resolve<ITimerServiceManager>();
            InitTimer(timerServiceManager);
            ChessboardField.IsReadonly = false;
        }

        public string Timer
        {
            get
            {
                return _gameTime;
            }
            set
            {
                _gameTime = value;
                OnPropertyChanged(nameof(Timer));
            }
        }

        public RelayCommand PlayGameCommand { get; set; }

        public PawnBase SelectedPawn { get; private set; }
        public bool IsTipsEnabled { get; set; }

        public int NumberOfTips
        {
            get { return _numberOfTips; }
            set
            {
                _numberOfTips = value;
                OnPropertyChanged(nameof(NumberOfTips));
            }
        }

        public int NumberOfLeftPawns
        {
            get { return _numberOfLeftPawns; }
            set
            {
                _numberOfLeftPawns = value;
                OnPropertyChanged(nameof(NumberOfLeftPawns));
            }
        }

        public int NumberOfMistakes
        {
            get { return _numberOfMistakes; }
            set
            {
                _numberOfMistakes = value;
                OnPropertyChanged(nameof(NumberOfMistakes));
            }
        }

        public RelayCommand RestartGameCommand { get; set; }

        public void Update()
        {
            Timer = _timerServiceBase.TimerValue;
        }

        private void InitTimer(ITimerServiceManager timerServiceManager)
        {
            if (timerServiceManager != null)
                _timerServiceBase = timerServiceManager.GetTimer(GameSettings.GameType.Timer, 100);
            _timerServiceBase.InitTimer(this);
        }

        private void LoadGameSettings()
        {
            SelectedPawn = GameSettings.SelectedPawn;
            NumberOfLeftPawns = GameSettings.SelectedPawn.NumberOfPawns;
            if (TryToMakeIt != null)
            {
                Timer = TryToMakeIt.MaxTime.ToString();
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
            NumberOfTips = 0;
        }
    }
}
