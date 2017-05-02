using System.Windows.Media;
using EightQueensPuzzle.Services;

namespace EightQueensPuzzle
{
    public class TipService : ITipService
    {
        private readonly IChessboardValidatorStrategy _validator;

        public TipService(IChessboardValidatorStrategy validator)
        {
            _validator = validator;
        }

        public SolidColorBrush GetChangedFieldColor(ChessboardField chessboardField)
        {
            if (!IsDefaultColor(chessboardField.CurrentFieldColor as SolidColorBrush))
                return FieldColorHelper.DefaultFieldColor;
            return _validator.Validate(chessboardField) ? FieldColorHelper.GoodFieldColor : FieldColorHelper.BadFieldColor;
        }

        private static bool IsDefaultColor(SolidColorBrush color)
            => !(color.Equals(FieldColorHelper.GoodFieldColor) || color.Equals(FieldColorHelper.BadFieldColor));
    }
}
