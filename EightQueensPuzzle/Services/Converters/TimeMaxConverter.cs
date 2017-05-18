using System.Collections.Generic;
using EightQueensPuzzle.Models.GameTypes;

namespace EightQueensPuzzle.Services.Converters
{
    public class TimeMaxConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            TryToMakeIt.GameTypeName
        };
    }
}
