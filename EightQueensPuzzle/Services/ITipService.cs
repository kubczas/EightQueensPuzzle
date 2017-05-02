using System.Windows.Media;

namespace EightQueensPuzzle.Services
{
    public interface ITipService
    {
        SolidColorBrush GetChangedFieldColor(ChessboardField chessboardField);
    }
}
