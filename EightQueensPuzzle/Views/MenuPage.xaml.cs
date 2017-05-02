using System;
using System.Windows;
using System.Windows.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void NavigateToBoard(object sender, RoutedEventArgs e)
        {
            BoardPage page = new BoardPage();
            this.NavigationService.Navigate(page);
        }
    }
}
