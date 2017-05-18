using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EightQueensPuzzle.Services;
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
    }
}
