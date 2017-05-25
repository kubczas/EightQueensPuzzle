﻿using EightQueensPuzzle.Constants;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Models.GameTypes
{
    public class DoNotMakeMistakes : GameType
    {
        public const int NumberOfTips = 0;
        public int MaxMistakes { get; set; }
        public override string GameTypeName => GameTypeNames.DontMakeMistakes;
        public override TimerType Timer => TimerType.TimerIncrease;
    }
}
