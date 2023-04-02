using ArtworkManager.Windows;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Nein.Base;

namespace ArtworkManager.Views;

public partial class ArtworkBrowserView : ReactiveControl<ArtworkBrowserViewModel>
{
    public ArtworkBrowserView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void OpenFullscreen_OnClick(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(ViewModel?.SelectedArtwork?.Filepath)) return;

        var fullscreenWindow = new FullscreenWindow(ViewModel.SelectedArtwork.Filepath);

        fullscreenWindow.Show();
    }
}