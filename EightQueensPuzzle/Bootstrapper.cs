using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Constraints;
using EightQueensPuzzle.Services.Timer;
using EightQueensPuzzle.ViewModels;
using EightQueensPuzzle.Views;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle
{
    public class Bootstrapper
    {
        public static UnityContainer Container { get; set; }

        public static void Init()
        {
            UnityService.Instance.Get().
                RegisterType<MainWindow>(new ContainerControlledLifetimeManager()).
                RegisterType<MenuPage>().
                RegisterType<SettingsViewModel>(new ContainerControlledLifetimeManager()).
                RegisterType<IChessboard, Chessboard>(new ContainerControlledLifetimeManager()).
                RegisterType<IConstraintFactory, ConstraintFactory>().
                RegisterType<IChessboardValidatorManager, CheesboardValidatorManager>(new ContainerControlledLifetimeManager()).
                RegisterType<ITipService, TipService>(new ContainerControlledLifetimeManager()).
                RegisterType<ITimerServiceManager, TimerServiceManager>();
        }
    }
}