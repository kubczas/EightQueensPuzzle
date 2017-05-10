using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public interface IGameType
    {
        TimerType Timer { get; }
        int NumberOfTips { get; }
    }
}
