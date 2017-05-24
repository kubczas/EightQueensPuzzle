using System.Collections.Generic;
using EightQueensPuzzle.Constants;

namespace EightQueensPuzzle.Services.Converters
{
    public class NumberOfPossibleMistakesConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            GameTypeNames.WinAsSoonAsPossible,
            GameTypeNames.TryToMakeIt
        };
    }
}
