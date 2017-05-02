using System;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class BishopValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public override bool Validate(ChessboardField chessboardField)
        {
            throw new NotImplementedException();
        }

        public override string Error { get; }
    }
}
