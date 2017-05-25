using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.ViewModels;

namespace EightQueensPuzzle.Helpers
{
    public static class ImageHelper
    {
        private static IDictionary<Pawn, BitmapImage> _bitmapImagesStrategy;
        private static readonly BitmapImage PawnImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\pawn..png", UriKind.Relative));
        private static readonly BitmapImage RookImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\rook.png", UriKind.Relative));
        private static readonly BitmapImage BishopImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\bishop.png", UriKind.Relative));
        private static readonly BitmapImage QueenImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\queen.png", UriKind.Relative));
        private static readonly BitmapImage KingImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\king.png", UriKind.Relative));
        private static readonly BitmapImage KnightImage = new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\knight.png", UriKind.Relative));

        static ImageHelper()
        {
            InitStrategy();
        }

        private static void InitStrategy()
        {
            _bitmapImagesStrategy = new Dictionary<Pawn, BitmapImage>
            {
                {Pawn.Pawn, PawnImage},
                {Pawn.Bishop, BishopImage},
                {Pawn.Knight, KnightImage},
                {Pawn.Rook, RookImage},
                {Pawn.King, KingImage},
                {Pawn.Queen, QueenImage}
            };
        }

        public static BitmapImage GetPawnImage()
        {
            return _bitmapImagesStrategy[ViewModelBase.GameSettings.SelectedPawn];
        }
    }
}
