using System;
using System.Linq;
using EightQueensPuzzle.Models;
using Extenstions;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class VerticalConstraint : ConstraintBase
    {
        internal VerticalConstraint(IChessboard chessboard) : base(chessboard){}

        public override bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return ExecuteConstraintPredicate(field => field.Column == destinationChessboardField.Column);
        }

        public override bool IsConstraintMet(ChessboardField destinationChessboardField, int scope)
        {
            return ExecuteConstraintPredicate(field => field.Column.IsWithin(destinationChessboardField.Column, scope));
        }
    }
}
