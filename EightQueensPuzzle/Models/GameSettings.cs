using System.Collections.ObjectModel;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public class GameSettings
    {
        private static GameSettings _instance;
        private ObservableCollection<string> _gameTypeNames; 

        private GameSettings()
        {
            
        }

        public static GameSettings Instance => _instance ?? new GameSettings();

        public Pawn SelectedPawn { get; private set; } = Pawn.Queen;

        public bool EnableTips { get; private set; }

        public int MaxTime { get; private set; } = 120;

        public IGameType SelectedGameType { get; private set; } = new TryToMakeIt(50,50);
    }
}
