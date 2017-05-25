using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;
using WpfUtilities;

namespace EightQueensPuzzle.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly IGameTypeFactory _gameTypeFactory;
        private readonly IChessPawnFactory _chessPawnFactory;
        private readonly IDialogCoordinator _dialogCoordinator;
        private string _selectedGameType;
        private int _selectedPawn;
        private int _numberOfTips;
        private int _timeMax;
        private int _numberOfPossibleMistakes;
        private bool _isTipsEnabled;
        private ObservableCollection<string> _gameTypes;

        public SettingsViewModel(ISettingsService settingsService, IGameTypeFactory gameTypeFactory, IChessPawnFactory chessPawnFactory, IDialogCoordinator dialogCoordinator) : base(settingsService)
        {
            _settingsService = settingsService;
            _gameTypeFactory = gameTypeFactory;
            _chessPawnFactory = chessPawnFactory;
            _dialogCoordinator = dialogCoordinator;
            _selectedGameType = GameTypes.FirstOrDefault();
            SaveCommand = new DelegateCommand(SaveSettings);
            LoadSettings();
        }

        public DelegateCommand SaveCommand { get; set; }

        public ObservableCollection<string> GameTypes => _gameTypes ?? (_gameTypes = new ObservableCollection<string>()
        {
            GameTypeNames.DontMakeMistakes,
            GameTypeNames.TryToMakeIt,
            GameTypeNames.WinAsSoonAsPossible
        });

        public string SelectedGameType
        {
            get { return _selectedGameType; }
            set
            {
                _selectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public int TimeMax
        {
            get { return _timeMax; }
            set
            {
                _timeMax = value;
                OnPropertyChanged(nameof(TimeMax));
            }
        }

        public int NumberOfTips
        {
            get { return _numberOfTips; }
            set
            {
                _numberOfTips = value;
                OnPropertyChanged(nameof(NumberOfTips));
            }
        }

        public int NumberOfPossibleMistakes
        {
            get { return _numberOfPossibleMistakes; }
            set
            {
                _numberOfPossibleMistakes = value;
                OnPropertyChanged(nameof(NumberOfPossibleMistakes));
            }
        }

        public bool IsTipsEnabled
        {
            get { return _isTipsEnabled; }
            set
            {
                _isTipsEnabled = value;
                OnPropertyChanged(nameof(IsTipsEnabled));
            }
        }

        public int SelectedPawnIndex
        {
            get { return _selectedPawn; }
            set
            {
                _selectedPawn = value;
                OnPropertyChanged(nameof(SelectedPawnIndex));
            }
        }

        private void LoadSettings()
        {
            SetGameTypeSettings();
        }

        private async void SaveSettings(object obj)
        {
            ProgressDialogController controller = await _dialogCoordinator.ShowProgressAsync(this, "Saving", "Saving");
            controller.SetIndeterminate();

            GameSettings.SelectedPawn = _chessPawnFactory.CreatePawn(_selectedPawn + 1);
            GameSettings.GameType = _gameTypeFactory.CreateGameType(SelectedGameType, TimeMax, NumberOfTips, NumberOfPossibleMistakes,
                IsTipsEnabled);
            _settingsService.Save(GameSettings);

            await controller.CloseAsync();
        }

        private void SetGameTypeSettings()
        {
            SelectedPawnIndex = GameSettings.SelectedPawn.Order - 1;
            SelectedGameType = GameSettings.GameType.GameTypeName;

            if (TryToMakeIt != null)
            {
                TimeMax = TryToMakeIt.MaxTime;
                NumberOfTips = TryToMakeIt.NumberOfTips;
            }
            if (WinAsSoonAsPossible != null)
            {
                TimeMax = WinAsSoonAsPossible.MaxTime;
                NumberOfTips = WinAsSoonAsPossible.NumberOfTips;
            }
            if (DoNotMakeMistakes != null)
            {
                NumberOfPossibleMistakes = DoNotMakeMistakes.MaxMistakes;
            }
        }
    }
}
