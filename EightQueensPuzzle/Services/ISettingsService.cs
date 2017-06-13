using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public interface ISettingsService
    {
        int TimeMax { get; }
        int NumberOfMistakes { get; }
        bool AreTipsEnabled { get; }
        GameSettings Load();
        void Save(GameSettings gameSettings);  
    }
}
