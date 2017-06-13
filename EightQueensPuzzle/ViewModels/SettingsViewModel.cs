using System.Collections.ObjectModel;
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
        private readonly IGameTypeFactory _gameTypeFactory;
        private readonly IChessPawnFactory _chessPawnFactory;

        private string _selectedGameType;
        private int _selectedPawn;
        private bool _isTipsEnabled;
        private ObservableCollection<string> _gameTypes;

        public SettingsViewModel(ISettingsService settingsService, IGameTypeFactory gameTypeFactory, IChessPawnFactory chessPawnFactory, IDialogCoordinator dialogCoordinator, IChessboard chessboard) : base(settingsService, dialogCoordinator, chessboard)
        {
            _gameTypeFactory = gameTypeFactory;
            _chessPawnFactory = chessPawnFactory;
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
                if (value.Equals(GameTypeNames.DontMakeMistakes))
                    IsTipsEnabled = false;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public int TimeMax
        {
            get { return TimeLimit; }
            set
            {
                TimeLimit = value;
                OnPropertyChanged(nameof(TimeMax));
            }
        }

        public int NumberOfMistakes
        {
            get { return NumberOfPossibleMistakes; }
            set
            {
                NumberOfPossibleMistakes = value;
                OnPropertyChanged(nameof(NumberOfMistakes));
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
            var controller = DialogCoordinator.ShowMessageAsync(this, "Saving", "Saving");

            GameSettings.SelectedPawn = _chessPawnFactory.CreatePawn(_selectedPawn + 1);
            GameSettings.GameType = _gameTypeFactory.CreateGameType(SelectedGameType, TimeMax, NumberOfMistakes, IsTipsEnabled);
            SettingsService.Save(GameSettings);
            Chessboard.ClearChessboard();

            await controller;
        }

        private void SetGameTypeSettings()
        {
            SelectedPawnIndex = GameSettings.SelectedPawn.Order - 1;
            SelectedGameType = GameSettings.GameType.GameTypeName;
            TimeMax = SettingsService.TimeMax;
            NumberOfMistakes = SettingsService.NumberOfMistakes;
            IsTipsEnabled = SettingsService.AreTipsEnabled;
        }
    }
}
