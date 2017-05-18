using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class WinAsSoonAsPossible : GameSettingsBase
    {
        public WinAsSoonAsPossible(int numberOfTips, int maxTime)
        {
            NumberOfTips = numberOfTips;
            MaxTime = maxTime;
        }

        public const string GameTypeName = "Win as soon as possible";
        public override TimerType Timer => TimerType.TimerIncrease;
        public override int NumberOfTips { get; }
        public int MaxTime { get; }
    }
}
