using System.Collections.ObjectModel;
using BaseReuseServices;
using EightQueensPuzzle.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    public class BoardViewModel : BindableBase
    {
        private readonly IChessboard _chessboard;
        public BoardViewModel()
        {
            _chessboard = UnityService.Instance.Resolve<IChessboard>();
            _chessboard.InitChessboard();
        }

        public ObservableCollection<ChessboardField> GameBoard => _chessboard.ChessboardFields;

        public int Size => _chessboard.ChessboardSize;
    }
}
