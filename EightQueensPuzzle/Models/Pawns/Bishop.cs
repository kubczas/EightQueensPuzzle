using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Bishop : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"..\..\Resources\Icons\bishop.png", UriKind.Relative));
        public override int NumberOfPawns => 14;
        public override int Order => 3;
        public override string Name => "Bishop";
    }
}
