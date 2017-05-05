using System.Windows.Media;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;

namespace EightQueensPuzzle
{
    public class TipService : ITipService
    {
        private readonly IChessboardValidatorManager _validatorManager;

        public TipService(IChessboardValidatorManager validatorManager)
        {
            _validatorManager = validatorManager;
        }

        public SolidColorBrush GetChangedFieldColor(ChessboardField chessboardField)
        {
            if (!IsDefaultColor(chessboardField.CurrentFieldColor as SolidColorBrush))
                return FieldColorHelper.DefaultFieldColor;
            return _validatorManager.GetChessboardValidatorStrategy(GameSettings.SelectedPawn).Validate(chessboardField) ? FieldColorHelper.GoodFieldColor : FieldColorHelper.BadFieldColor;
        }

        private static bool IsDefaultColor(SolidColorBrush color)
            => !(color.Equals(FieldColorHelper.GoodFieldColor) || color.Equals(FieldColorHelper.BadFieldColor));
    }
}
