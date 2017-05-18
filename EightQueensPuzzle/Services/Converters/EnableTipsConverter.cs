﻿using System.Collections.Generic;
using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services.Converters
{
    public class EnableTipsConverter : ConverterBase
    {
        public override IList<string> AvailableGameTypes { get; protected set; } = new List<string>()
        {
            TryToMakeIt.GameTypeName,
            WinAsSoonAsPossible.GameTypeName
        };
    }
}
