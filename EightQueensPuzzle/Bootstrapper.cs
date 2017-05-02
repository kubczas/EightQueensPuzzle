using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Services;
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
                RegisterType<ITipService, TipService>().
                RegisterType<IChessboardValidatorStrategy, QueenValidatorStrategy>().
                RegisterType<IChessboardValidatorManager, CheesboardValidatorManager>().
                RegisterType<IChessboard, Chessboard>();
        }

    }
}