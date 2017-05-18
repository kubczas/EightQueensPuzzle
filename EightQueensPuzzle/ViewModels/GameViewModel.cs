using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Timer;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle.ViewModels
{
    public class GameViewModel : BindableBase, IObserver
    {
        private string _gameTime = "90";
        private TimerServiceBase _timerServiceBase;

        public GameViewModel()
        {
            ITimerServiceManager timerServiceManager = UnityService.Instance.Get().Resolve<ITimerServiceManager>();
            InitTimer(timerServiceManager);
        }

        public string Timer
        {
            get
            {
                return _gameTime;
            }
            set
            {
                _gameTime = value;
                OnPropertyChanged(nameof(Timer));
            }
        }

        public void Update()
        {
            Timer = _timerServiceBase.TimerValue;
        }

        private void InitTimer(ITimerServiceManager timerServiceManager)
        {
            if (timerServiceManager != null)
                _timerServiceBase = timerServiceManager.GetTimer(GameSettings.Instance.SelectedGameType.Timer);
            _timerServiceBase.InitTimer(this);
        }
    }
}
