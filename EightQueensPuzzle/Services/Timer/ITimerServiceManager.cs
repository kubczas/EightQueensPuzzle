using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Services.Timer
{
    public interface ITimerServiceManager
    {
        TimerServiceBase GetTimer(TimerType timerType, int timerService);
    }
}
