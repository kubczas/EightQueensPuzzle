namespace EightQueensPuzzle.Models
{
    public abstract class GameType : IGameType
    {
        public abstract string GameTypeName { get; }
    }
}
