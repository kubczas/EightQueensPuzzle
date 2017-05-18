using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Helpers
{
    public static class ImageHelper
    {
        private static BitmapImage _queenPawn;

        public static BitmapImage QueenPawn => _queenPawn ?? (_queenPawn = new BitmapImage(new Uri(@"White_Queen_Finish.png", UriKind.Relative)));
    }
}
