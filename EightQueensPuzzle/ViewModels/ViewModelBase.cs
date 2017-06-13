using System;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected readonly ISettingsService SettingsService;
        protected readonly IDialogCoordinator DialogCoordinator;
        protected readonly IChessboard Chessboard;
        protected int TimeLimit = int.MaxValue;
        protected int NumberOfPossibleMistakes;

        protected ViewModelBase(ISettingsService settingsService, IDialogCoordinator dialogCoordinator, IChessboard chessboard)
        {
            SettingsService = settingsService;
            DialogCoordinator = dialogCoordinator;
            Chessboard = chessboard;
            Load();
        }

        public static GameSettings GameSettings { get; protected set; }

        protected void Load()
        {
            try
            {
                GameSettings = SettingsService.Load();
            }
            catch (Exception)
            {
                GameSettings = new GameSettings();
            }
        }
    }
}
