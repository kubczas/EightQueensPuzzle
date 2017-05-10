using BaseReuseServices;
using EightQueensPuzzle.Views;
using MahApps.Metro.Controls;
using Microsoft.Practices.Unity;

namespace EightQueensPuzzle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = UnityService.Instance.Get().Resolve(typeof(MenuPage));
        }
    }
}
