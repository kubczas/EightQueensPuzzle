﻿using BaseReuseServices;
using EightQueensPuzzle.Models;
using EightQueensPuzzle.Models.GameTypes;
using EightQueensPuzzle.Services;
using EightQueensPuzzle.Services.Constraints;
using EightQueensPuzzle.Services.Timer;
using EightQueensPuzzle.ViewModels;
using EightQueensPuzzle.Views;
using MahApps.Metro.Controls.Dialogs;
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
                RegisterType<IGameType, TryToMakeIt>("TryToMakeIt").
                RegisterType<IGameType, WinAsSoonAsPossible>("WinAsSoonAsPossible").
                RegisterType<IGameType, DoNotMakeMistakes>("DoNotMakeMistakes").
                RegisterType<IGameViewModel, GameViewModel>(new ContainerControlledLifetimeManager()).
                RegisterType<IChessPawnFactory, ChessPawnFactory>().
                RegisterType<IDialogCoordinator, DialogCoordinator>().
                RegisterType<IGameTypeFactory, GameTypeFactory>(new ContainerControlledLifetimeManager()).
                RegisterType<IXmlFileSerializer, XmlFileSerializer>(new ContainerControlledLifetimeManager()).
                RegisterType<ISettingsService, SettingsService>(new ContainerControlledLifetimeManager()).
                RegisterType<SettingsViewModel>(new ContainerControlledLifetimeManager()).
                RegisterType<GameViewModel>(new ContainerControlledLifetimeManager()).
                RegisterType<InfoViewModel>().
                RegisterType<IChessboard, Chessboard>(new ContainerControlledLifetimeManager()).
                RegisterType<IConstraintFactory, ConstraintFactory>().
                RegisterType<IChessboardValidatorManager, CheesboardValidatorManager>(
                    new ContainerControlledLifetimeManager()).
                RegisterType<ITipService, TipService>(new ContainerControlledLifetimeManager()).
                RegisterType<ITimerServiceManager, TimerServiceManager>().
                RegisterType<IXmlFileSerializer, XmlFileSerializer>();
        }
    }
}