using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class WinAsSoonAsPossible : GameType
    {
        public int MaxTime { get; set; }
        public int NumberOfTips { get; set; }
        public override string GameTypeName => GameTypeNames.WinAsSoonAsPossible;
        public override TimerType Timer => TimerType.TimerIncrease;
    }
}
