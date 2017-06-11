using System;
using System.Timers;

namespace EightQueensPuzzle.Services.Timer
{
    public class DecreaseTimer : TimerServiceBase
    {
        public override bool IsCountingFinished { get; protected set; }

        public override void InitTimer(IObserver viewModel)
        {
            Time = StartTime;
            IsCountingFinished = false;
            GameTimer.Elapsed += new ElapsedEventHandler(DecreaseTime);
            GameTimer.Interval = 1000;
            GameTimer.Enabled = true;
            Subscribe(viewModel);
        }

        public override void Reset()
        {
            Time = StartTime;
            GameTimer.Stop();
        }

        private void DecreaseTime(object sender, EventArgs e)
        {
            if (Time > 0)
                TimerValue = Time--;
            else
            {
                IsCountingFinished = true;
                GameTimer.Stop();
                GameTimer.Close();
            }
            Notify();
        }
    }
}
