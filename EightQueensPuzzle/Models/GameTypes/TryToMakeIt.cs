using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class TryToMakeIt : GameType
    {
        public const TimerType Timer = TimerType.TimerDecrease;
        public int MaxTime { get; set; }
        public int NumberOfTips { get; set; }
        public override string GameTypeName => GameTypeNames.TryToMakeIt;
    }
}
