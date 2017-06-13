using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.GameTypes;

namespace EightQueensPuzzle.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IXmlFileSerializer _xmlFileSerializer;
        private GameType _settingsCache;
        private readonly IDictionary<Type, Action> _strategy;

        private static readonly string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            Assembly.GetCallingAssembly().FullName);

        public SettingsService(IXmlFileSerializer xmlFileSerializer)
        {
            _xmlFileSerializer = xmlFileSerializer;
            _strategy = new Dictionary<Type, Action>();
            InitStrategy();
        }

        public int TimeMax { get; private set; }

        public int NumberOfMistakes { get; private set; }

        public bool AreTipsEnabled => _settingsCache.IsTipsEnabled;

        public GameSettings Load()
        {
            var settings = _xmlFileSerializer.Deserialize<GameSettings>(FilePath);
            _settingsCache = settings.GameType;
            _strategy[_settingsCache.GetType()].Invoke();
            return settings;
        }

        public void Save(GameSettings gameSettings)
        {
            _xmlFileSerializer.Serialize(FilePath, gameSettings);
        }

        private void InitStrategy()
        {
            _strategy.Add(typeof(TryToMakeIt), SetTryToMakeIt);
            _strategy.Add(typeof(DoNotMakeMistakes), SetDoNotMakeMistakes);
            _strategy.Add(typeof(WinAsSoonAsPossible), SetWinAsSoonAsPossible);
        }

        private void SetWinAsSoonAsPossible()
        {
            var winAsSoonAsPossible = _settingsCache as WinAsSoonAsPossible;
            if (winAsSoonAsPossible != null) TimeMax = winAsSoonAsPossible.MaxTime;
            NumberOfMistakes = int.MaxValue;
        }

        private void SetDoNotMakeMistakes()
        {
            var doNotMakeMistakes = _settingsCache as DoNotMakeMistakes;
            TimeMax = int.MaxValue;
            if (doNotMakeMistakes != null) NumberOfMistakes = doNotMakeMistakes.MaxMistakes;
        }

        private void SetTryToMakeIt()
        {
            var tryToMakeIt = _settingsCache as TryToMakeIt;
            if (tryToMakeIt == null) return;

            TimeMax = tryToMakeIt.MaxTime;
            NumberOfMistakes = int.MaxValue;
        }
    }
}
