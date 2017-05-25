using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class RookValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public RookValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return ConstraintFactory.GetHorizontalConstraint().IsConstraintMet(destinationChessboardField) &&
                   ConstraintFactory.GetVerticalConstraint().IsConstraintMet(destinationChessboardField);
        }

        public override string Error { get; }
    }
}
