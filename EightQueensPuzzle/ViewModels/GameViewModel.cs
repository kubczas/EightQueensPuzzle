using BaseReuseServices;
using EightQueensPuzzle.Models.GameTypes;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Timer;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle.ViewModels
{
    public class GameViewModel : ViewModelBase, IObserver
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

        private void InitTimer(ITimerServiceManager timerServiceManager) //it should be launch after button play will be clicked
        {
            if (timerServiceManager != null)
                _timerServiceBase = timerServiceManager.GetTimer(TryToMakeIt.Timer,100);
            _timerServiceBase.InitTimer(this);
        }
    }
}
