using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public abstract class GameType : IGameType
    {
        public abstract string GameTypeName { get; }
        public abstract TimerType Timer { get; }
    }
}
