﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueensPuzzle.Services.ValidationStrategy
{
    public class RookValidatorStrategy : ChessPawnValidatorStrategyBase
    {
        public override bool Validate(ChessboardField chessboardField)
        {
            throw new NotImplementedException();
        }

        public override string Error { get; }
    }
}