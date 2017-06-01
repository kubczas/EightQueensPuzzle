using System.Collections.ObjectModel;

namespace EightQueensPuzzle.Models
{
    public interface IChessboard
    {
        ObservableCollection<ChessboardField> ChessboardFields { get; }

        int ChessboardSize { get; }
        void InitChessboard();
    }
}
