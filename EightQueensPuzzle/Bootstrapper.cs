using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Constraints;
using EightQueensPuzzle.Services.ValidationStrategy;
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
                RegisterType<BoardPage>().
                RegisterType<MenuPage>().
                RegisterType<IChessboard, Chessboard>(new ContainerControlledLifetimeManager()).
                RegisterType<IConstraintFactory, ConstraintFactory>().
                RegisterType<IChessboardValidatorManager, CheesboardValidatorManager>(
                    new ContainerControlledLifetimeManager()).
                RegisterType<ITipService, TipService>(new ContainerControlledLifetimeManager());

        }

    }
}