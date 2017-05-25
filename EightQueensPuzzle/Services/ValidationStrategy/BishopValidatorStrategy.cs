using System;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services.Constraints;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class BishopValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public BishopValidatorStrategy(IConstraintFactory constraintFactory) : base(constraintFactory)
        {
        }

        public override bool Validate(ChessboardField destinationChessboardField)
        {
            return ConstraintFactory.GetDiagonalConstraint().IsConstraintMet(destinationChessboardField);
        }

        public override string Error { get; }
    }
}
