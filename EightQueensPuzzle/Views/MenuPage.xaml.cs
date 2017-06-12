using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace EightQueensPuzzle.Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private IDictionary<string, Page> _navigationStrategy;
        private BoardPage _boardPage;
        private SettingsPage _settingsPage;
        private AboutPage _aboutPage;

        public MenuPage()
        {
            InitializeComponent();
            InitializePages();
            InitNavigationStrategy();
        }

        private void InitializePages()
        {
            _aboutPage = new AboutPage();
            _boardPage = new BoardPage();
            _settingsPage = new SettingsPage();
        }

        private IDictionary<string, Page> InitNavigationStrategy()
        {
            return new Dictionary<string, Page>
            {
                {"Play", _boardPage},
                {"Settings", _settingsPage},
                {"About", _aboutPage}
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
