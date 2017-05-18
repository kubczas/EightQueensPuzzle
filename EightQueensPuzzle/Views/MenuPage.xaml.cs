using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using EightQueensPuzzle.Services;
using MahApps.Metro.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private IDictionary<string, Page> _navigationStrategy; 
        public MenuPage()
        {
            InitializeComponent();
            InitNavigationStrategy();
        }

        private IDictionary<string, Page> InitNavigationStrategy()
        {
            return new Dictionary<string, Page>
            {
                {"Play", new BoardPage()},
                {"Settings", new SettingsPage()},
                {"Help", null}
            };
        }

        private void Navigate(object obj, RoutedEventArgs routedEventArgs)
        {
            try
            {
                if(_navigationStrategy==null)
                    _navigationStrategy = InitNavigationStrategy();
                var tile = (Tile) obj;
                var navigationService = NavigationService;
                navigationService?.Navigate(_navigationStrategy[tile.Title]);
            }
            catch (InvalidCastException) { }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
