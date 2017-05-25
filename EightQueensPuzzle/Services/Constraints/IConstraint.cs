using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    public interface IConstraint
    {
        bool IsConstraintMet(ChessboardField destinationChessboardField);

        bool IsConstraintMet(ChessboardField destinationChessboardField, int scope);
    }
}
