using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class HorizontalConstraint : IHorizontalConstraint
    {
        private readonly IChessboard _chessboard;

        internal HorizontalConstraint(IChessboard chessboard)
        {
            _chessboard = chessboard;
        }

        public bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return _chessboard.ChessboardFields.
                Where(field => field.Column == destinationChessboardField.Column).
                All(chessboardField => !chessboardField.IsPawnSet);
        }
    }
}
