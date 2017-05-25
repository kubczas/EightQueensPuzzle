using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public abstract class ChessPawnValidatorStrategyBase : IChessboardValidatorStrategy
    {
        protected readonly IConstraintFactory ConstraintFactory;

        protected ChessPawnValidatorStrategyBase(IConstraintFactory constraintFactory)
        {
            ConstraintFactory = constraintFactory;
        }

        public abstract bool Validate(ChessboardField chessboardField);

        public abstract string Error { get; }
    }
}
