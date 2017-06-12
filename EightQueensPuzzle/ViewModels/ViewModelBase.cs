using System;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.GameTypes;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        private readonly ISettingsService _settingsService;
        protected readonly IDialogCoordinator DialogCoordinator;
        protected readonly IChessboard Chessboard;
        protected int TimeLimit = int.MaxValue;
        protected int NumberOfPossibleMistakes;

        protected ViewModelBase(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard)
        {
            _settingsService = settingsService;
            DialogCoordinator = dialogCoordinator;
            Chessboard = chessboard;
            Load();
        }

        public static GameSettings GameSettings { get; protected set; }
        protected TryToMakeIt TryToMakeIt => GameSettings.GameType as TryToMakeIt;
        protected WinAsSoonAsPossible WinAsSoonAsPossible => GameSettings.GameType as WinAsSoonAsPossible;
        protected DoNotMakeMistakes DoNotMakeMistakes => GameSettings.GameType as DoNotMakeMistakes;

        protected void Load()
        {
            try
            {
                GameSettings = _settingsService.Load();
            }
            catch (Exception)
            {
                GameSettings = new GameSettings();
            }
        }
    }
}
