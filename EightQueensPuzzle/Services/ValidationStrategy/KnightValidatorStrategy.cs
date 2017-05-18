using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class KnightValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public override bool Validate(ChessboardField chessboardField)
        {
            throw new NotImplementedException();
        }

        public override string Error { get; }
    }
}
