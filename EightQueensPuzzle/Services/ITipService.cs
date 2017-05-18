using System.Windows.Media;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public interface ITipService
    {
        SolidColorBrush GetChangedFieldColor(ChessboardField chessboardField);
    }
}
