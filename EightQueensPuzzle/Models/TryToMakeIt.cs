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
        public int NumberOfTips { get; set; }
        public int MaxTime { get; }
    }
}
