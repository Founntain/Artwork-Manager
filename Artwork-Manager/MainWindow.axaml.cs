using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using ArtworkManager.Windows;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtworkManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowBaseViewModel(this);
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void OpenSettings_Click(object? sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog(this);
        }

        private void ManageArtworks_Click(object? sender, RoutedEventArgs e)
        {
            var artworkBrowser = new ArtworkBrowser();
            artworkBrowser.Show(this);
        }
    }
}