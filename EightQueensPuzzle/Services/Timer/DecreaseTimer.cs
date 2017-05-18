using System;
using System.Timers;

namespace EightQueensPuzzle.Services.Timer
{
    public class DecreaseTimer : TimerServiceBase
    {
        public override void InitTimer(IObserver viewModel)
        {
            GameTimer.Elapsed += new ElapsedEventHandler(DecreaseTime);
            GameTimer.Interval = 1000;
            GameTimer.Enabled = true;
            Subscribe(viewModel);
        }

        private void DecreaseTime(object sender, EventArgs e)
        {
            if (Time >= 0)
                TimerValue = (Time--).ToString();
            else
            {
                GameTimer.Stop();
                GameTimer.Close();
            }
            Notify();
        }
    }
}
