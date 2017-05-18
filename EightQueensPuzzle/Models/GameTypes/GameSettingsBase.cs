using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public abstract class GameSettingsBase : IGameType
    {
        public static Pawn SelectedPawn { get; } = Pawn.Queen;
        public abstract TimerType Timer { get; }
        public abstract int NumberOfTips { get; }
    }
}
