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
            int row = destinationChessboardField.Row+2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column-1, row))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == destinationChessboardField.Column - 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidUpRightDirection(ChessboardField destinationChessboardField)
        {
            int row = destinationChessboardField.Row + 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column + 1, row))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == destinationChessboardField.Column + 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidDownLeftDirection(ChessboardField destinationChessboardField)
        {
            int row = destinationChessboardField.Row - 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column - 1, row))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == destinationChessboardField.Column - 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidDownRightDirection(ChessboardField destinationChessboardField)
        {
            int row = destinationChessboardField.Row - 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column + 1, row))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == destinationChessboardField.Column + 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidLeftUpDirection(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Column - 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Row - 1, column))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Column == column && field.Row == destinationChessboardField.Row - 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidRightUpDirection(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Column + 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column + 1, column))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Column == column && field.Row == destinationChessboardField.Row + 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidLeftDownDirection(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Row - 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column - 1, column))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Column == column && field.Row == destinationChessboardField.Row - 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }

        private bool ValidRightDownDirection(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Column + 2;
            if (AreValuesInChessboardSizeScope(destinationChessboardField.Column + 1, column))
            {
                var knightDestination = Chessboard.ChessboardFields.FirstOrDefault(field => field.Column == column && field.Row == destinationChessboardField.Row + 1);
                return knightDestination != null && !knightDestination.IsPawnSet;
            }
            return false;
        }
    }
}
