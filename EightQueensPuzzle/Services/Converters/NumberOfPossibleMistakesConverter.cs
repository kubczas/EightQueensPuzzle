using System.Collections.Generic;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Converters
{
    public class NumberOfPossibleMistakesConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            DoNotMakeMistakes.GameTypeName,
        };
    }
}
