using System;

namespace EightQueensPuzzle.Services.Timer
{
    public class IncreaseTimer : TimerServiceBase
    {
        public IncreaseTimer()
        {
            Time = 0;
        }

        public override void InitTimer(IObserver viewModel)
        {
            IsCountingFinished = false;
            GameTimer.Elapsed += IncreaseTime;
            GameTimer.Interval = 1000;
            Subscribe(viewModel);
        }

        private void IncreaseTime(object sender, EventArgs e)
        {
            TimerValue = Time++;
            Notify();
        }
    }
}
