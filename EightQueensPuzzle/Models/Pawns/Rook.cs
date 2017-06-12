using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Rook : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"..\..\Resources\Icons\rook.png", UriKind.Relative));
        public override int NumberOfPawns => 8;
        public override int Order => 4;
        public override string Name => "Rook";
    }
}
