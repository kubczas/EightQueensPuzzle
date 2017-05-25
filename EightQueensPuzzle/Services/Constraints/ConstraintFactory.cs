using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Constraints
{
    public class ConstraintFactory : IConstraintFactory
    {
        private readonly IChessboard _chessboard;
        public ConstraintFactory(IChessboard chessboard)
        {
            _chessboard = chessboard;
        }

        public IConstraint GetDiagonalConstraint()
        {
            return new DiagonalConstraint(_chessboard);
        }

        public IConstraint GetHorizontalConstraint()
        {
            return new HorizontalConstraint(_chessboard);
        }

        public IConstraint GetVerticalConstraint()
        {
            return new VerticalConstraint(_chessboard);
        }

        public IConstraint GetKnightConstraint()
        {
            return new KnightConstraint(_chessboard);
        }
    }
}
