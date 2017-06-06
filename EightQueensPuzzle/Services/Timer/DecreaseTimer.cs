using System;
using System.Timers;

namespace EightQueensPuzzle.Services.Timer
{
    public class DecreaseTimer : TimerServiceBase
    {
        public override bool IsCountingFinished => TimerValue == 0;

        public override void InitTimer(IObserver viewModel)
        {
            GameTimer.Elapsed += new ElapsedEventHandler(DecreaseTime);
            GameTimer.Interval = 1000;
            GameTimer.Enabled = true;
            Subscribe(viewModel);
        }

        public override void Restart()
        {
            Time = StartTime;
        }

        private void DecreaseTime(object sender, EventArgs e)
        {
            if (Time >= 0)
                TimerValue = Time--;
            else
            {
                GameTimer.Stop();
                GameTimer.Close();
            }
            Notify();
        }
    }
}
