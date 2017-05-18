using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class QueenValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        private readonly IConstraintFactory _constraintFactory;

        public QueenValidatorStrategy(IConstraintFactory constraintFactory)
        {
            _constraintFactory = constraintFactory;
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return _constraintFactory.GetDiagonalConstraint().IsConstraintMet(destinationChessboardField) &&
                   _constraintFactory.GetHorizontalConstraint().IsConstraintMet(destinationChessboardField) &&
                   _constraintFactory.GetVerticalConstraint().IsConstraintMet(destinationChessboardField);
        }

        public override string Error { get; }
    }
}
