using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class KingValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public KingValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField chessboardField)
        {
            return ConstraintFactory.GetDiagonalConstraint().IsConstraintMet(chessboardField, 1) &&
                   ConstraintFactory.GetHorizontalConstraint().IsConstraintMet(chessboardField, 1) &&
                   ConstraintFactory.GetVerticalConstraint().IsConstraintMet(chessboardField, 1);
        }

        public override string Error { get; }
    }
}
