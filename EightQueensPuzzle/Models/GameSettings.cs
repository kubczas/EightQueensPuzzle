using System.Xml.Serialization;
using EightQueensPuzzle.Enums;
using EightQueensPuzzle.Models.GameTypes;

namespace EightQueensPuzzle.Models
{
    public class GameSettings
    {
        public Pawn SelectedPawn { get; set; }

        [XmlElement(typeof(DoNotMakeMistakes))]
        [XmlElement(typeof(WinAsSoonAsPossible))]
        [XmlElement(typeof(TryToMakeIt))]
        public GameType GameType { get; set; }
    }
}
