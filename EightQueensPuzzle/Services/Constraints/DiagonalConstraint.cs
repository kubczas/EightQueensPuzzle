using System.Linq;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class DiagonalConstraint : IDiagonalConstraint
    {
        private readonly IChessboard _chessboard;

        internal DiagonalConstraint(IChessboard chessboard)
        {
            _chessboard = chessboard;
        }

        public bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return CheckFirstDiagonal(destinationChessboardField) && CheckSecondDiagonal(destinationChessboardField);
        }

        private bool CheckFirstDiagonal(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Column, row = destinationChessboardField.Row;
            while (column>=0&&row>=0)
            {
                var currentField = _chessboard.ChessboardFields.FirstOrDefault(field => field.Row==row && field.Column==column);
                if (currentField != null && currentField.IsPawnSet)
                    return false;
                column--;
                row--;
            }

            column = destinationChessboardField.Column;
            row = destinationChessboardField.Row;
            while (column < _chessboard.ChessboardSize && row < _chessboard.ChessboardSize)
            {
                var currentField = _chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == column);
                if (currentField != null && currentField.IsPawnSet)
                    return false;
                column++;
                row++;
            }
            return true;
        }

        private bool CheckSecondDiagonal(ChessboardField destinationChessboardField)
        {
            int column = destinationChessboardField.Column, row = destinationChessboardField.Row;
            while (column < _chessboard.ChessboardSize && row >= 0)
            {
                var currentField = _chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == column);
                if (currentField != null && currentField.IsPawnSet)
                    return false;
                column++;
                row--;
            }

            column = destinationChessboardField.Column;
            row = destinationChessboardField.Row;
            while (column >= 0 && row < _chessboard.ChessboardSize)
            {
                var currentField = _chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == column);
                if (currentField != null && currentField.IsPawnSet)
                    return false;
                column--;
                row++;
            }
            return true;
        }
    }
}
