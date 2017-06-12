using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Pawn : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"..\..\Resources\Icons\pawn.png", UriKind.Relative));
        public override int NumberOfPawns => 32;
        public override int Order => 1;
        public override string Name => "Pawn";
    }
}
