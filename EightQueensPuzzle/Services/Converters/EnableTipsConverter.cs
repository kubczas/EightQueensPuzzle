﻿using System.Collections.Generic;
using EightQueensPuzzle.Constants;

namespace EightQueensPuzzle.Services.Converters
{
    public class EnableTipsConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            GameTypeNames.TryToMakeIt,
            GameTypeNames.WinAsSoonAsPossible
        };
    }
}
