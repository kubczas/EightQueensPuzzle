using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class QueenValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public QueenValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return ConstraintFactory.GetDiagonalConstraint().IsConstraintMet(destinationChessboardField) &&
                   ConstraintFactory.GetHorizontalConstraint().IsConstraintMet(destinationChessboardField) &&
                   ConstraintFactory.GetVerticalConstraint().IsConstraintMet(destinationChessboardField);
        }

        public override string Error { get; }
    }
}
