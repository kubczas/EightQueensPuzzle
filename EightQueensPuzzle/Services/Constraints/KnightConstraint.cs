using System.Linq;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class KnightConstraint : ConstraintBase
    {
        public KnightConstraint(IChessboard chessboard) : base(chessboard)
        {
        }

        public override bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return ValidUpLeftDirection(destinationChessboardField) && ValidUpRightDirection(destinationChessboardField) &&
                   ValidDownLeftDirection(destinationChessboardField) && ValidDownRightDirection(destinationChessboardField) &&
                   ValidLeftUpDirection(destinationChessboardField) && ValidRightUpDirection(destinationChessboardField) &&
                   ValidLeftDownDirection(destinationChessboardField) && ValidRightDownDirection(destinationChessboardField);
        }

        public override bool IsConstraintMet(ChessboardField destinationChessboardField, int scope)
        {
            return true;
        }

        private bool ValidUpLeftDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column - 1, destinationChessboardField.Row + 2);
        }

        private bool ValidUpRightDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column + 1, destinationChessboardField.Row + 2);
        }

        private bool ValidDownLeftDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column - 1, destinationChessboardField.Row - 2);
        }

        private bool ValidDownRightDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column + 1, destinationChessboardField.Row - 2);
        }

        private bool ValidLeftUpDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column - 2, destinationChessboardField.Row - 1);
        }

        private bool ValidRightUpDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column + 2, destinationChessboardField.Row + 1);
        }

        private bool ValidLeftDownDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column - 2, destinationChessboardField.Row + 1);
        }

        private bool ValidRightDownDirection(ChessboardField destinationChessboardField)
        {
            return ValidKnightPosition(destinationChessboardField.Column + 2, destinationChessboardField.Row + 1);
        }

        private bool ValidKnightPosition(int column, int row)
        {
            if (!AreValuesInChessboardSizeScope(column, row)) return true;

            var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == column);
            return knightDestination != null && !knightDestination.IsPawnSet;
        }
    }
}
