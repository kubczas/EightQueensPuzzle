﻿using System;
using System.Windows.Media.Imaging;

namespace EightQueensPuzzle.Models.Pawns
{
    public class Knight : PawnBase
    {
        public override BitmapImage Image => new BitmapImage(new Uri(@"..\..\Resources\Icons\knight.png", UriKind.Relative));
        public override int NumberOfPawns => 32;
        public override int Order => 2;
        public override string Name => "Knight";
    }
}
