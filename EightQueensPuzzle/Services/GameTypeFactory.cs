using System;
using System.Collections.Generic;
using System.Linq;
using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.GameTypes;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle.Services
{
    public class GameTypeFactory : IGameTypeFactory
    {
        private IDictionary<Type, Func<GameType>> _gameTypeStrategy;
        private static IEnumerable<IGameType> _gameTypes;
        private int _timeMax;
        private bool _isTipsEnabled;
        private int _numberOfMistakes;


        public GameTypeFactory()
        {
            _gameTypes = UnityService.Instance.Get().ResolveAll<IGameType>();
            InitStrategy();
        }

        public GameType CreateGameType(string selectedGameType, int timeMax, int numberOfMistakes, bool isTipsEnabled)
        {
            SetSettings(timeMax, numberOfMistakes, isTipsEnabled);
            var gameType = _gameTypes.FirstOrDefault(type => type.GameTypeName.Equals(selectedGameType));
            var func = _gameTypeStrategy[gameType.GetType()];
            return func.Invoke();
        }

        private void SetSettings(int timeMax, int numberOfMistakes, bool isTipsEnabled)
        {
            _timeMax = timeMax;
            _numberOfMistakes = numberOfMistakes;
            _isTipsEnabled = isTipsEnabled;
        }

        private void InitStrategy()
        {
            _gameTypeStrategy = new Dictionary<Type, Func<GameType>>
            {
                {typeof (TryToMakeIt), SetTryToMakeItSettings},
                {typeof (WinAsSoonAsPossible), SetWinAsSoonAsPossibleSettings},
                {typeof (DoNotMakeMistakes), SetDoNotMakeMistakesSettings}
            };
        }

        private GameType SetDoNotMakeMistakesSettings()
        {
            var doNotMakeMistakes =
                                    (DoNotMakeMistakes)_gameTypes.First(type => type.GetType() == typeof(DoNotMakeMistakes));
            doNotMakeMistakes.MaxMistakes = _numberOfMistakes;
            doNotMakeMistakes.IsTipsEnabled = _isTipsEnabled;
            return doNotMakeMistakes;
        }

        private GameType SetWinAsSoonAsPossibleSettings()
        {
            var winAsSoonAsPossible =
                                    (WinAsSoonAsPossible)_gameTypes.First(type => type.GetType() == typeof(WinAsSoonAsPossible));
            winAsSoonAsPossible.IsTipsEnabled = _isTipsEnabled;
            return winAsSoonAsPossible;
        }

        private GameType SetTryToMakeItSettings()
        {
            var tryToMakeIt =
                                    (TryToMakeIt)_gameTypes.First(type => type.GetType() == typeof(TryToMakeIt));
            tryToMakeIt.MaxTime = _timeMax;
            tryToMakeIt.IsTipsEnabled = _isTipsEnabled;
            return tryToMakeIt;
        }
    }
}
