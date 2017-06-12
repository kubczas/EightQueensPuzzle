using System.Windows;
using System.Windows.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }
    }
}
