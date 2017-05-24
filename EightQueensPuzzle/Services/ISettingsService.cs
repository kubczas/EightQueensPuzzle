using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public interface ISettingsService
    {
        GameSettings Load();
        void Save(GameSettings gameSettings);
    }
}
