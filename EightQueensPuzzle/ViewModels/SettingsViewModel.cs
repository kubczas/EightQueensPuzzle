using System.Collections.ObjectModel;
using System.Linq;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    internal class SettingsViewModel : BindableBase
    {
        private string _selectedGameType;
        private int _selectedPawn;
        private int _numberOfTips;
        private int _numberOfPossibleMistakes;
        private bool _isTipsEnabled;
        private ObservableCollection<string> _gameTypes;

        public SettingsViewModel()
        {
            _selectedGameType = GameTypes.FirstOrDefault();
        }

        public Pawn SelectedPawn { get; set; }

        public string SelectedGameType
        {
            get { return _selectedGameType; }
            set
            {
                _selectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public string SelectedGameDescription => $"Selected Pawn: {SelectedPawn} \nSelected game type: {SelectedGameType}";

        public object DisplaySelectedGameDescription
        {
            get { return string.Empty; }
        }

        public ObservableCollection<string> GameTypes => _gameTypes ?? (_gameTypes = new ObservableCollection<string>()
        {
            DoNotMakeMistakes.GameTypeName,
            TryToMakeIt.GameTypeName,
            WinAsSoonAsPossible.GameTypeName
        });

        public int TimeMax { get; set; }

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
    }
}
