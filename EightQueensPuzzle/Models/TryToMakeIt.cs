using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public class TryToMakeIt : IGameType
    {
        public TryToMakeIt(int numberOfTips, int maxTime)
        {
            NumberOfTips = numberOfTips;
            MaxTime = maxTime;
        }

        public const string GameTypeName = "Try to make it";
        public TimerType Timer => TimerType.TimerDecrease;
        public int NumberOfTips { get; }
        public int MaxTime { get; }
    }
}
