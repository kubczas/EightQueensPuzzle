using System;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.GameTypes;
using EightQueensPuzzle.Services;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        private readonly ISettingsService _settingsService;

        protected ViewModelBase(ISettingsService settingsService)
        {
            _settingsService = settingsService;
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
