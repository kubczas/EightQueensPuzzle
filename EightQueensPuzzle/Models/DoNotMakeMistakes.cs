using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public class DoNotMakeMistakes : IGameType
    {
        public DoNotMakeMistakes(int possibleMistakes)
        {
            MaxMistakes = possibleMistakes;
        }

        public const string GameTypeName = "Do not make mistakes";
        public TimerType Timer => TimerType.TimerIncrease;
        public int NumberOfTips => 0;
        public int MaxMistakes { get; }
    }
}
