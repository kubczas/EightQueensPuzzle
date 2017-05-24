using EightQueensPuzzle.Models;

namespace EightQueensPuzzle.Services
{
    public interface IGameTypeFactory
    {
        GameType CreateGameType(string selectedGameType, int timeMax, int numberOfTips, int numberOfMistakes, bool isTipsEnabled);
    }
}
