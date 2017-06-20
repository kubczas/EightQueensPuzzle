using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class DoNotMakeMistakes : GameType
    {
        public int MaxMistakes { get; set; }
        public override string GameTypeName => GameTypeNames.DontMakeMistakes;
        public override TimerType Timer => TimerType.TimerIncrease;
        public override bool IsTipsEnabled { get; set; } = false;

        public override string Description =>
            "Do not make mistakes - in this game, you're trying to avoid every mistake. In the settings panel user can set value of max possible mistakes. When the player did more mistakes than possible, the game is over.\r\n" +
            "The tips are obviously disabled and timer has increasing value.";
    }
}
