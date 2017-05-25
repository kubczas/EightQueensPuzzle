using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Bishop : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\bishop.png", UriKind.Relative));
        public override int NumberOfPawns => 14;
        public override int Order => 3;
    }
}
