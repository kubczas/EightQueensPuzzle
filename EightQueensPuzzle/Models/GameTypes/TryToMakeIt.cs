using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class TryToMakeIt : GameSettingsBase
    {
        public TryToMakeIt(int numberOfTips, int maxTime)
        {
            NumberOfTips = numberOfTips;
            MaxTime = maxTime;
        }

        public const string GameTypeName = "Try to make it";
        public override TimerType Timer => TimerType.TimerDecrease;
        public override int NumberOfTips { get; }
        public int MaxTime { get; }
    }
}
