using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class TryToMakeIt : GameType
    {
        public int MaxTime { get; set; }
        public override string GameTypeName => GameTypeNames.TryToMakeIt;
        public override TimerType Timer => TimerType.TimerDecrease;
        public override bool IsTipsEnabled { get; set; } = false;
    }
}
