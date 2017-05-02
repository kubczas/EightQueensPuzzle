using System.Collections.Generic;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Services.ValidationStrategy;

namespace EightQueensPuzzle.Services
{
    public class CheesboardValidatorManager : IChessboardValidatorManager
    {
        private static IDictionary<Pawn, IChessboardValidatorStrategy> _chessboardValidatorStrategies;
        public CheesboardValidatorManager()
        {
            _chessboardValidatorStrategies = new Dictionary<Pawn, IChessboardValidatorStrategy>
            {
                {Pawn.Pawn, new PawnValidatorStrategy()},
                {Pawn.Bishop, new BishopValidatorStrategy()},
                {Pawn.King, new KingValidatorStrategy()},
                {Pawn.Knight, new KnightValidatorStrategy()},
                {Pawn.Queen, new QueenValidatorStrategy()},
                {Pawn.Rook, new RookValidatorStrategy()}
            };
        }

        public IChessboardValidatorStrategy GetChessboardValidatorStrategy(Pawn pawnType)
        {
            IChessboardValidatorStrategy result;
            _chessboardValidatorStrategies.TryGetValue(pawnType, out result);
            return result;
        }
    }
}
