using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public abstract class GameType : IGameType
    {
        public abstract string GameTypeName { get; }
        public abstract TimerType Timer { get; }
        public abstract bool IsTipsEnabled { get; set; }
        public abstract string Description { get; }
    }
}
