using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Services
{
    public interface IChessboardValidatorManager
    {
        IChessboardValidatorStrategy GetChessboardValidatorStrategy(Pawn pawnType);
    }
}
