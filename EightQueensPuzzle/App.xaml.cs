using System.Windows;
using EightQueensPuzzle.ViewModels;
using Microsoft.Practices.Unity;
using WpfUtilities;

namespace EightQueensPuzzle
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bootstrapper.Init();
        }
    }
}
