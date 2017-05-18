using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public class WinAsSoonAsPossible : IGameType
    {
        public WinAsSoonAsPossible(int numberOfTips, int maxTime)
        {
            NumberOfTips = numberOfTips;
            MaxTime = maxTime;
        }

        public const string GameTypeName = "Win as soon as possible";
        public TimerType Timer => TimerType.TimerIncrease;
        public int NumberOfTips { get; set; }//todo
        public int MaxTime { get; }
    }
}
