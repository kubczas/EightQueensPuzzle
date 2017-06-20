using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;

namespace EightQueensPuzzle.ViewModels
{
    public class AboutViewModel : ViewModelBase
    {
        private string _description;
        public AboutViewModel(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard) : base(settingsService, dialogCoordinator, chessboard)
        {
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
    }
}
