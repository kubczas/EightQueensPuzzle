using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class WinAsSoonAsPossible : GameType
    {
        public int MaxTime { get; set; }
        public override string GameTypeName => GameTypeNames.WinAsSoonAsPossible;
        public override TimerType Timer => TimerType.TimerIncrease;
        public override bool IsTipsEnabled { get; set; } = true;
        public override string Description =>
            "Win as soon as possible - in this game, you're trying to win game as soon as possible." +
            "The tips could be enabled and timer has increasing value.";
    }
}
