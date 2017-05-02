using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class QueenValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public override bool Validate(ChessboardField chessboardField)
        {
            return true;
        }

        public override string Error { get; }
    }
}
