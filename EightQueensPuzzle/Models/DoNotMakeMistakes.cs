using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Services;

namespace EightQueensPuzzle.Models
{
    public class DoNotMakeMistakes : IGameType
    {
        public const string GameTypeName = "Do not make mistakes";
        public TimerType Timer => TimerType.TimerIncrease;
        public int NumberOfTips => 0;
        public int MaxMistakes { get; set; }
    }
}
