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
            GameTypeDescriptions.DontMakeMistakes;
    }
}
