using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public interface IChessboardValidatorStrategy
    {
        bool Validate(ChessboardField chessboardField);
        string Error { get; }
    }
}