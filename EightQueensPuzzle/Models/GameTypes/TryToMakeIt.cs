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
        public override string Description =>
            "Try to make it - in this game, you're trying to win game before time is up. In the settings panel user can set value of time in seconds. When the player did not win game during appointed time, the game is over.\r\n" +
            "The tips could be enabled and timer has decreasing value.";
    }
}
