using EightQueensPuzzle.Models;
using Extenstions;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class HorizontalConstraint : ConstraintBase
    {
        internal HorizontalConstraint(IChessboard chessboard) : base(chessboard){}

        public override bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return ExecuteConstraintPredicate(field => field.Row == destinationChessboardField.Row);
        }

        public override bool IsConstraintMet(ChessboardField destinationChessboardField, int scope)
        {
            return ExecuteConstraintPredicate(field => field.Column==destinationChessboardField.Column && field.Row.IsWithin(destinationChessboardField.Row, scope));
        }
    }
}
