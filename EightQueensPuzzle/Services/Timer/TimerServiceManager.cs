using System.Collections.Generic;
using EightQueensPuzzle.Enums;

namespace EightQueensPuzzle.Services.Timer
{
    public class TimerServiceManager : ITimerServiceManager
    {
        private static IDictionary<TimerType, TimerServiceBase> _timerServiceStrategy;

        public static IDictionary<TimerType, TimerServiceBase> TimerServiceStrategy => _timerServiceStrategy ?? (_timerServiceStrategy = new Dictionary<TimerType, TimerServiceBase>
        {
            {TimerType.TimerDecrease, new DecreaseTimer()},
            {TimerType.TimerIncrease, new IncreaseTimer()}
        });

        public TimerServiceBase GetTimer(TimerType timerType)
        {
            return TimerServiceStrategy[timerType];
        }
    }
}
