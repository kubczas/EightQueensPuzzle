using System.Linq;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class DiagonalConstraint : ConstraintBase
    {
        private delegate int FieldCalculation(int currentPosition);
        private FieldCalculation _rowCalculation;
        private FieldCalculation _columnCalculation;

        internal DiagonalConstraint(IChessboard chessboard) : base(chessboard){}

        public override bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return CheckFirstDiagonal(destinationChessboardField) && CheckSecondDiagonal(destinationChessboardField);
        }

        public override bool IsConstraintMet(ChessboardField destinationChessboardField, int scope)
        {
            return CheckFirstDiagonal(destinationChessboardField, scope) && CheckSecondDiagonal(destinationChessboardField, scope);
        }

        private bool CheckSecondDiagonal(ChessboardField destinationChessboardField, int? scope = null)
        {
            return CheckFirstDiagonalTowardsRightUpDirection(destinationChessboardField, scope) && CheckFirstDiagonalTowardsLeftDownDirection(destinationChessboardField, scope);
        }

        private bool CheckFirstDiagonal(ChessboardField destinationChessboardField, int? scope = null)
        {
            return CheckFirstDiagonalTowardsLeftUpDirection(destinationChessboardField, scope) && CheckFirstDiagonalTowardsRightDownDirection(destinationChessboardField, scope);
        }

        private bool CheckFirstDiagonalTowardsRightDownDirection(ChessboardField destinationChessboardField, int? scope = null)
        {
            _rowCalculation += IncreaseIndex;
            _columnCalculation += IncreaseIndex;
            return ValidateDiagonal(destinationChessboardField.Row, destinationChessboardField.Column, scope);
        }

        private bool CheckFirstDiagonalTowardsLeftUpDirection(ChessboardField destinationChessboardField, int? scope = null)
        {
            _rowCalculation += DecreaseIndex;
            _columnCalculation += DecreaseIndex;
            return ValidateDiagonal(destinationChessboardField.Row, destinationChessboardField.Column, scope);
        }

        private bool CheckFirstDiagonalTowardsLeftDownDirection(ChessboardField destinationChessboardField, int? scope = null)
        {
            _rowCalculation += IncreaseIndex;
            _columnCalculation += DecreaseIndex;
            return ValidateDiagonal(destinationChessboardField.Row, destinationChessboardField.Column, scope);
        }

        private bool CheckFirstDiagonalTowardsRightUpDirection(ChessboardField destinationChessboardField, int? scope = null)
        {
            _rowCalculation += DecreaseIndex;
            _columnCalculation += IncreaseIndex;
            return ValidateDiagonal(destinationChessboardField.Row, destinationChessboardField.Column, scope);
        }

        private bool ValidateDiagonal(int row, int column, int? scope = null)
        {
            int startRow = row;
            int startColumn = column;
            while (AreValuesInChessboardSizeScope(column, row, scope, startColumn, startRow))
            {
                var currentField = Chessboard.ChessboardFields.FirstOrDefault(field => field.Row == row && field.Column == column);
                if (currentField != null && currentField.IsPawnSet)
                    return false;
                column = _columnCalculation(column);
                row = _rowCalculation(row);
            }
            return true;
        }

        private static int DecreaseIndex(int index)
        {
            return index - 1;
        }

        private static int IncreaseIndex(int index)
        {
            return index + 1;
        }
    }
}
