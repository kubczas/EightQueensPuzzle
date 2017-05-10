using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models
{
    public class WinAsSoonAsPossible : IGameType
    {
        public const string GameTypeName = "Win as soon as possible";
        public TimerType Timer => TimerType.TimerIncrease;
        public int NumberOfTips { get; set; } = 10;//todo
    }
}
