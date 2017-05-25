using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Knight : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"C:\Users\Kubczas\documents\visual studio 2015\Projects\EightQueensPuzzle\EightQueensPuzzle\Resources\knight.png", UriKind.Relative));
        public override int NumberOfPawns => 32;
        public override int Order => 2;
    }
}
