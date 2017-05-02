using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public abstract class ChessPawnValidatorStrategyBase : IChessboardValidatorStrategy
    {
        public abstract bool Validate(ChessboardField chessboardField);

        public abstract string Error { get; }
    }
}
