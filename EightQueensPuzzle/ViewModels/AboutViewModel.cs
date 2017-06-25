using System.Collections.Generic;
using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;

namespace EightQueensPuzzle.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private IDictionary<int, string> _gameTypeDescriptionStrategy;
        private string _description;

        public AboutViewModel(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard) : base(settingsService, dialogCoordinator, chessboard)
        {
            InitStrategy();
        }

        private void InitStrategy()
        {
            _gameTypeDescriptionStrategy = new Dictionary<int, string>
            {
                {-1, string.Empty },
                {0, GameTypeDescriptions.TryToMakeIt},
                {1, GameTypeDescriptions.WinAsSoonAsPossible},
                {2, GameTypeDescriptions.DontMakeMistakes}
            };
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public int SelectedGameTypeDescription
        {
            set
            {
                Description = _gameTypeDescriptionStrategy[value];
            }
        }
    }
}
