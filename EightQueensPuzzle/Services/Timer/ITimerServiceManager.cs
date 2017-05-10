using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Services.Timer
{
    internal interface ITimerServiceManager
    {
        TimerServiceBase GetTimer(TimerType timerType);
    }
}
