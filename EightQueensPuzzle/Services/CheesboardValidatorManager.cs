using System;
using System.Collections.Generic;
using EightQueensPuzzle.Models.Pawns;
using EightQueensPuzzle.Services.Constraints;
using EightQueensPuzzle.Services.ValidationStrategy;

namespace EightQueensPuzzle.Services
{
    public class CheesboardValidatorManager : IChessboardValidatorManager
    {
        private static IConstraintFactory _constraintFactory;
        private static IDictionary<Type, IChessboardValidatorStrategy> _chessboardValidatorStrategies;

        public CheesboardValidatorManager(IConstraintFactory constraintFactory)
        {
            _constraintFactory = constraintFactory;
        }

        public static IDictionary<Type, IChessboardValidatorStrategy> ChessboardValidatorStrategies
            => _chessboardValidatorStrategies ??
               (_chessboardValidatorStrategies = InitStrategy());

        public IChessboardValidatorStrategy GetChessboardValidatorStrategy(Type pawnType)
        {
            IChessboardValidatorStrategy result;
            ChessboardValidatorStrategies.TryGetValue(pawnType, out result);
            return result;
        }

        private static IDictionary<Type, IChessboardValidatorStrategy> InitStrategy()
        {
            return new Dictionary<Type, IChessboardValidatorStrategy>(){
                {typeof(Pawn), new PawnValidatorStrategy(_constraintFactory)},
                {typeof(Bishop), new BishopValidatorStrategy(_constraintFactory)},
                {typeof(King), new KingValidatorStrategy(_constraintFactory)},
                {typeof(Knight), new KnightValidatorStrategy(_constraintFactory)},
                {typeof(Queen), new QueenValidatorStrategy(_constraintFactory)},
                {typeof(Rook), new RookValidatorStrategy(_constraintFactory)}
            };
        }
    }
}
