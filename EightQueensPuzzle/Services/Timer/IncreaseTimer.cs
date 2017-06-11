using System;
using System.Timers;

namespace EightQueensPuzzle.Services.Timer
{
    public class IncreaseTimer : TimerServiceBase
    {
        public IncreaseTimer()
        {
            Time = 0;
        }

        public override bool IsCountingFinished { get; protected set; } = false;

        public override void InitTimer(IObserver viewModel)
        {
            IsCountingFinished = false;
            GameTimer.Elapsed += new ElapsedEventHandler(IncreaseTime);
            GameTimer.Interval = 1000;
            GameTimer.Enabled = true;
            Subscribe(viewModel);
        }

        public override void Reset()
        {
            Time = 0;
            GameTimer.Stop();
        }

        private void IncreaseTime(object sender, EventArgs e)
        {
            TimerValue = Time++;
            Notify();
        }
    }
}
