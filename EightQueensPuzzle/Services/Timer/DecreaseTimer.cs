using System;

namespace EightQueensPuzzle.Services.Timer
{
    public class DecreaseTimer : TimerServiceBase
    {
        public override void InitTimer(IObserver viewModel)
        {
            Time = StartTime;
            IsCountingFinished = false;
            GameTimer.Elapsed += DecreaseTime;
            GameTimer.Interval = 1000;
            Subscribe(viewModel);
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
