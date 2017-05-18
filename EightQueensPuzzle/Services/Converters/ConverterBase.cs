using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace EightQueensPuzzle.Services.Converters
{
    public abstract class ConverterBase : IValueConverter
    {
        public abstract IList<string> AvailableGameTypes { get; protected set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return AvailableGameTypes.Contains((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
