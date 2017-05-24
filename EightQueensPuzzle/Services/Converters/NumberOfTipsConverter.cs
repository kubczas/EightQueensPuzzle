using System.Collections.Generic;
using EightQueensPuzzle.Constants;

namespace EightQueensPuzzle.Services.Converters
{
    public class NumberOfTipsConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            GameTypeNames.DontMakeMistakes
        };
    }
}
