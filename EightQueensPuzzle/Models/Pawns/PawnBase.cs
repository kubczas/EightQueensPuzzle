using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public abstract class PawnBase
    {
        public abstract BitmapImage Image { get; }
        public abstract int NumberOfPawns { get; }
        public abstract int Order { get; }
    }
}
