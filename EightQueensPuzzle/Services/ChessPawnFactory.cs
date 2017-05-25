using System.Collections.Generic;
using EightQueensPuzzle.Models.Pawns;

namespace EightQueensPuzzle.Services
{
    public class ChessPawnFactory : IChessPawnFactory
    {
        private IDictionary<int, PawnBase> _prioPawnStrategy; 

        public ChessPawnFactory()
        {
            InitStrategy();
        }

        private void InitStrategy()
        {
            _prioPawnStrategy = new Dictionary<int, PawnBase>
            {
                {1, new Pawn()},
                {2, new Knight()},
                {3, new Bishop()},
                {4, new Rook()},
                {5, new Queen()},
                {6, new King()}
            };
        }

        public PawnBase CreatePawn(int chessPrio)
        {
            return _prioPawnStrategy[chessPrio];
        }
    }
}
