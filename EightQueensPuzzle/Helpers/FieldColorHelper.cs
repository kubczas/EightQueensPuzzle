using System.Windows.Media;

namespace EightQueensPuzzle.Helpers
{
    public static class FieldColorHelper
    {
        public static readonly SolidColorBrush GoodFieldColor = new SolidColorBrush(Color.FromRgb(139,195,74));
        public static readonly SolidColorBrush BadFieldColor = new SolidColorBrush(Color.FromRgb(229, 57, 53));
        public static readonly SolidColorBrush DefaultFieldColor = new SolidColorBrush(Color.FromRgb(100,181,246));
    }
}