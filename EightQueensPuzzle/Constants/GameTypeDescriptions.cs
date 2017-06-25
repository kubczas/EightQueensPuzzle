namespace EightQueensPuzzle.Constants
{
    public class GameTypeDescriptions
    {
        public const string DontMakeMistakes = "Do not make mistakes - in this game, you're trying to avoid every mistake. In the settings panel user can set value of max possible mistakes. When the player did more mistakes than possible, the game is over.\r\n" +
            "The tips are obviously disabled and timer has increasing value.";
        public const string TryToMakeIt = "Try to make it - in this game, you're trying to win game before time is up. In the settings panel user can set value of time in seconds. When the player did not win game during appointed time, the game is over.\r\n" +
            "The tips could be enabled and timer has decreasing value.";
        public const string WinAsSoonAsPossible = "Win as soon as possible - in this game, you're trying to win game as soon as possible." +
            "The tips could be enabled and timer has increasing value.";
    }
}
