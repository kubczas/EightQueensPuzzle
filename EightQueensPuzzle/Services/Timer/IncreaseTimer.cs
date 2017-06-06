﻿using System;
using System.Timers;

namespace EightQueensPuzzle.Services.Timer
{
    public class IncreaseTimer : TimerServiceBase
    {
        public IncreaseTimer()
        {
            Time = 0;
        }

        public override bool IsCountingFinished => false;

        public override void InitTimer(IObserver viewModel)
        {
            GameTimer.Elapsed += new ElapsedEventHandler(IncreaseTime);
            GameTimer.Interval = 1000;
            GameTimer.Enabled = true;
            Subscribe(viewModel);
        }

        public override void Restart()
        {
            Time = 0;
        }

        private void IncreaseTime(object sender, EventArgs e)
        {
            TimerValue = Time++;
            Notify();
        }
    }
}
