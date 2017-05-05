using System.Collections.ObjectModel;

namespace EightQueensPuzzle.Models
{
    public class Chessboard : IChessboard
    {
        public Chessboard()
        {
            ChessboardSize = 8;
        }

        public int ChessboardSize { get; }

        public ObservableCollection<ChessboardField> ChessboardFields { get; private set; }

        public void InitChessboard()
        {
            ChessboardFields = new ObservableCollection<ChessboardField>();
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                    ChessboardFields.Add(new ChessboardField(i, j));
            }
        }
    }
}
