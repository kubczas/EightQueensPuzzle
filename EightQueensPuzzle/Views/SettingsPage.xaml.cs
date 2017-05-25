using System.Windows;
using System.Windows.Controls;
using EightQueensPuzzle.Enums;
using MahApps.Metro.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService?.GoBack();
        }

        private void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var flipview = ((FlipView)sender);
            var pawnEnum = (Pawn) flipview.SelectedIndex+1;
            flipview.BannerText = pawnEnum.ToString();
        }
    }
}
