using EightQueensPuzzle.Models.Pawns;

namespace EightQueensPuzzle.ViewModels
{
    interface IGameViewModel
    {
        PawnBase SelectedPawn { get; }
        bool IsTipsEnabled { get; set; }
        int NumberOfLeftPawns { get; set; }
        int NumberOfMistakes { get; set; }
    }
}
