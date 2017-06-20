using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;

namespace EightQueensPuzzle.ViewModels
{
    public class InfoViewModel : ViewModelBase
    {
        public InfoViewModel(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard)
            : base(settingsService, dialogCoordinator, chessboard)
        {
        }
    }
}
