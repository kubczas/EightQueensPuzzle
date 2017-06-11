using System;
using System.Collections.Generic;

namespace EightQueensPuzzle.Services.Timer
{
    public abstract class TimerServiceBase : IDisposable, ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        protected readonly System.Timers.Timer GameTimer;
        public int Time { get; protected set; }
        public int StartTime { get; set; }

        public abstract bool IsCountingFinished { get; protected set; }

        protected TimerServiceBase()
        {
            GameTimer = new System.Timers.Timer();
        }

        public int TimerValue { get; protected set; }

        public abstract void InitTimer(IObserver viewModel);

        public void Dispose()
        {
            GameTimer.Stop();
            GameTimer.Close();
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            _observers.ForEach(x => x.Update());
        }

        public abstract void Reset();
    }
}
