using EightQueensPuzzle.ViewModels;
using EightQueensPuzzle.Views;
using MahApps.Metro.Controls;
using WpfUtilities;

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
            MainFrame.Content = new MenuPage();
        }
    }
}
