using BaseReuseServices;
using EightQueensPuzzle.ViewModels;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle.Services
{
    public class ViewModelLocatorService
    {
        public SettingsViewModel SettingsViewModel => UnityService.Instance.Get().Resolve<SettingsViewModel>();

        public GameViewModel GameViewModel => UnityService.Instance.Get().Resolve<GameViewModel>();

        public BoardViewModel BoardViewModel => UnityService.Instance.Get().Resolve<BoardViewModel>();
    }
}
