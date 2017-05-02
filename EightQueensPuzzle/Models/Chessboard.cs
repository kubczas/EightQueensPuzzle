using System.Collections.ObjectModel;
using EightQueensPuzzle.Services;

namespace EightQueensPuzzle.Models
{
    public class Chessboard : IChessboard
    {
        private readonly IChessboardValidatorManager _chessboardValidatorManager;
        private readonly ITipService _tipService;

        public Chessboard(IChessboardValidatorManager chessboardValidatorManager, ITipService tipService)
        {
            _chessboardValidatorManager = chessboardValidatorManager;
            _tipService = tipService;
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
                    ChessboardFields.Add(new ChessboardField(i, j, _tipService, _chessboardValidatorManager.GetChessboardValidatorStrategy(GameSettings.SelectedPawn)));
            }
        }
    }
}
