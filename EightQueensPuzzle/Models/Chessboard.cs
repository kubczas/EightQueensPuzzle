using System.Collections.ObjectModel;
using Microsoft.Practices.ObjectBuilder2;

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
            for (var i = 0; i < ChessboardSize; i++)
            {
                for (var j = 0; j < ChessboardSize; j++)
                    ChessboardFields.Add(new ChessboardField(i, j));
            }
        }

        public void ClearChessboard()
        {
            ChessboardFields.ForEach(field => field.ClearField());
        }
    }
}
