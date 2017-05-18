using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class DoNotMakeMistakes : GameSettingsBase
    {
        public DoNotMakeMistakes(int possibleMistakes)
        {
            MaxMistakes = possibleMistakes;
        }

        public const string GameTypeName = "Do not make mistakes";
        public override TimerType Timer => TimerType.TimerIncrease;

        public override int NumberOfTips => 0;

        public int MaxMistakes { get; }
    }
}
