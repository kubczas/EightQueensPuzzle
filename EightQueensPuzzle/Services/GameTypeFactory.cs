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
        private int _numberTips;
        private int _numberOfMistakes;

        public GameTypeFactory()
        {
            _gameTypes = UnityService.Instance.Get().ResolveAll<IGameType>();
            InitStrategy();
        }

        public GameType CreateGameType(string selectedGameType, int timeMax, int numberOfTips, int numberOfMistakes,
            bool isTipsEnabled)
        {
            SetSettings(timeMax, numberOfTips, numberOfMistakes, isTipsEnabled);
            var gameType = _gameTypes.FirstOrDefault(type => type.GameTypeName.Equals(selectedGameType));
            var func = _gameTypeStrategy[gameType.GetType()];
            return func.Invoke();
        }

        private void SetSettings(int timeMax, int numberOfTips, int numberOfMistakes, bool isTipsEnabled)
        {
            _timeMax = timeMax;
            _numberTips = isTipsEnabled ? numberOfTips : 0;
            _numberOfMistakes = numberOfMistakes;
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
            return doNotMakeMistakes;
        }

        private GameType SetWinAsSoonAsPossibleSettings()
        {
            var winAsSoonAsPossible =
                                    (WinAsSoonAsPossible)_gameTypes.First(type => type.GetType() == typeof(WinAsSoonAsPossible));
            winAsSoonAsPossible.NumberOfTips = _numberTips;
            return winAsSoonAsPossible;
        }

        private GameType SetTryToMakeItSettings()
        {
            var tryToMakeIt =
                                    (TryToMakeIt)_gameTypes.First(type => type.GetType() == typeof(TryToMakeIt));
            tryToMakeIt.NumberOfTips = _numberTips;
            tryToMakeIt.MaxTime = _timeMax;
            return tryToMakeIt;
        }
    }
}
