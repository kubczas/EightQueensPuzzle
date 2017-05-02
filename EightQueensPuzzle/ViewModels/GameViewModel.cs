using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Practices.Prism.Mvvm;

namespace EightQueensPuzzle.ViewModels
{
    class GameViewModel : BindableBase
    {
        private readonly Timer _gameTimer = new System.Timers.Timer();
        private int expectedTime = 90;
        private string _gameTime = "90";

        public GameViewModel()
        {
            InitTimer();
        }

        public string Timer
        {
            get { return _gameTime; }
            set
            {
                _gameTime = value;
                OnPropertyChanged(nameof(Timer));
            }
        }

        private void InitTimer()
        {
            _gameTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _gameTimer.Interval = 1000;
            _gameTimer.Enabled = true;
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            Timer = (expectedTime--).ToString();
        }
    }
}
