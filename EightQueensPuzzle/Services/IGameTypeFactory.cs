using EightQueensPuzzle.Models.GameTypes;

namespace EightQueensPuzzle.Services
{
    public interface IGameTypeFactory
    {
        GameType CreateGameType(string selectedGameType, int timeMax, int numberOfMistakes, bool isTipsEnabled);
    }
}
