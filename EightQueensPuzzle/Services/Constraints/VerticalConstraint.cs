using System.Linq;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    internal class VerticalConstraint : IVerticalConstraint
    {
        private readonly IChessboard _chessboard;

        internal VerticalConstraint(IChessboard chessboard)
        {
            _chessboard = chessboard;
        }

        public bool IsConstraintMet(ChessboardField destinationChessboardField)
        {
            return _chessboard.ChessboardFields.
                Where(field => field.Row == destinationChessboardField.Row).
                All(chessboardField => !chessboardField.IsPawnSet);
        }
    }
}
