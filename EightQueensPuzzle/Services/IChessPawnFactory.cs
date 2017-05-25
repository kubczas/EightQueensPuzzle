using EightQueensPuzzle.Models.Pawns;

namespace EightQueensPuzzle.Services
{
    public interface IChessPawnFactory
    {
        PawnBase CreatePawn(int chessPrio);
    }
}
