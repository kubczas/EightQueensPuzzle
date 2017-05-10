using System;
using System.Collections.ObjectModel;
using System.Linq;
using EightQueensPuzzle.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    internal class SettingsViewModel : BindableBase
    {
        private string _selectedGameType;
        public SettingsViewModel()
        {
            _selectedGameType = GameSettings.Instance.GameTypeNames.FirstOrDefault();
        }

        public object FlipViewSelectionChanged
        {
            get { throw new NotImplementedException(); }
        }

        public ObservableCollection<string> GameTypes => GameSettings.Instance.GameTypeNames;

        public string SelectedGameType
        {
            get { return _selectedGameType; }
            set
            {
                _selectedGameType = value;
                OnPropertyChanged(nameof(SelectedGameType));
            }
        }

        public object SelectedGameDescription
        {
            get { return string.Empty; }
        }

        public object DisplaySelectedGameDescription
        {
            get { return string.Empty; }
        }
    }
}
