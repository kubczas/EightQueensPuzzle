using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class PawnValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public PawnValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return ConstraintFactory.GetHorizontalConstraint().IsConstraintMet(destinationChessboardField, 1) &&
                   ConstraintFactory.GetVerticalConstraint().IsConstraintMet(destinationChessboardField, 1);
        }

        public override string Error { get; }
    }
}
