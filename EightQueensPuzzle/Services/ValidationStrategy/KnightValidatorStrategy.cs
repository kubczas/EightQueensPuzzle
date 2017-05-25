using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class KnightValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public KnightValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return ConstraintFactory.GetKnightConstraint().IsConstraintMet(destinationChessboardField);
        }

        public override string Error { get; }
    }
}
