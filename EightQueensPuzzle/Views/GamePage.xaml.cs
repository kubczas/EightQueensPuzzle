using System.Windows;
using System.Windows.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for BoardPage.xaml
    /// </summary>
    public partial class BoardPage : Page
    {
        public BoardPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
