using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Models.Pawns;
using EightQueensPuzzle.ViewModels;

namespace EightQueensPuzzle.Helpers
{
    //public static class ImageHelper
    //{
    //    private static IDictionary<Type, BitmapImage> _bitmapImagesStrategy;

    //    static ImageHelper()
    //    {
    //        InitStrategy();
    //    }

    //    private static void InitStrategy()
    //    {
    //        _bitmapImagesStrategy = new Dictionary<Type, BitmapImage>
    //        {
    //            {typeof(Pawn), PawnImage},
    //            {typeof(Bishop), BishopImage},
    //            {typeof(Knight), KnightImage},
    //            {typeof(Rook), RookImage},
    //            {typeof(King), KingImage},
    //            {typeof(Queen), QueenImage}
    //        };
    //    }

    //    public static BitmapImage GetPawnImage(PawnBase pawn)
    //    {
    //        return _bitmapImagesStrategy[ViewModelBase.GameSettings.SelectedPawn];
    //    }
    //}
}
