using System.Collections.Generic;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Services.Constraints;
using EightQueensPuzzle.Services.ValidationStrategy;

namespace EightQueensPuzzle.Services
{
    public class CheesboardValidatorManager : IChessboardValidatorManager
    {
        private static IConstraintFactory _constraintFactory;
        private static IDictionary<Pawn, IChessboardValidatorStrategy> _chessboardValidatorStrategies;

        public CheesboardValidatorManager(IConstraintFactory constraintFactory)
        {
            _constraintFactory = constraintFactory;
        }

        public static IDictionary<Pawn, IChessboardValidatorStrategy> ChessboardValidatorStrategies
            => _chessboardValidatorStrategies ??
               (_chessboardValidatorStrategies = InitStrategy());

        public IChessboardValidatorStrategy GetChessboardValidatorStrategy(Pawn pawnType)
        {
            IChessboardValidatorStrategy result;
            ChessboardValidatorStrategies.TryGetValue(pawnType, out result);
            return result;
        }

        private static IDictionary<Pawn, IChessboardValidatorStrategy> InitStrategy()
        {
            return new Dictionary<Pawn, IChessboardValidatorStrategy>(){
                {Pawn.Pawn, new PawnValidatorStrategy()},
                {Pawn.Bishop, new BishopValidatorStrategy()},
                {Pawn.King, new KingValidatorStrategy()},
                {Pawn.Knight, new KnightValidatorStrategy()},
                {Pawn.Queen, new QueenValidatorStrategy(_constraintFactory)},
                {Pawn.Rook, new RookValidatorStrategy()}
            };
        }
    }
}
