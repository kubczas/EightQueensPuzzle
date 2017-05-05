using System;
using System.Linq;
using EightQueensPuzzle.Models;
using Extenstions;

namespace EightQueensPuzzle.Services.Constraints
{
    internal abstract class ConstraintBase : IConstraint
    {
        protected readonly IChessboard Chessboard;

        protected ConstraintBase(IChessboard chessboard)
        {
            Chessboard = chessboard;
        }

        protected bool ExecuteConstraintPredicate(Func<ChessboardField, bool> predicate)
        {
            return Chessboard.ChessboardFields.
                Where(predicate).
                All(chessboardField => !chessboardField.IsPawnSet);
        }
        protected bool AreValuesInChessboardSizeScope(int column, int row, int? scope = null)
        {
            if (scope.HasValue)
                return column.IsWithin(column, scope.Value) && row.IsWithin(row, scope.Value);
            return column.IsBetween(0, Chessboard.ChessboardSize - 1) && row.IsBetween(0, Chessboard.ChessboardSize - 1);
        }

        public abstract bool IsConstraintMet(ChessboardField destinationChessboardField);
        public abstract bool IsConstraintMet(ChessboardField destinationChessboardField, int scope);
    }
}
