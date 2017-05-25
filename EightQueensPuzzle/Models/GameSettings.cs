using System.Xml.Serialization;
using EightQueensPuzzle.Models.GameTypes;
using EightQueensPuzzle.Models.Pawns;

namespace EightQueensPuzzle.Models
{
    public class GameSettings
    {
        [XmlElement(typeof(Pawn))]
        [XmlElement(typeof(Bishop))]
        [XmlElement(typeof(Knight))]
        [XmlElement(typeof(Rook))]
        [XmlElement(typeof(Queen))]
        [XmlElement(typeof(King))]
        public PawnBase SelectedPawn { get; set; }

        [XmlElement(typeof(DoNotMakeMistakes))]
        [XmlElement(typeof(WinAsSoonAsPossible))]
        [XmlElement(typeof(TryToMakeIt))]
        public GameType GameType { get; set; }
    }
}
