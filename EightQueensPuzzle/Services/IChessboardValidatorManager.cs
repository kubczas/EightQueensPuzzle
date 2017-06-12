using System;

namespace EightQueensPuzzle.Services
{
    public interface IChessboardValidatorManager
    {
        IChessboardValidatorStrategy GetChessboardValidatorStrategy(Type pawnType);
    }
}
