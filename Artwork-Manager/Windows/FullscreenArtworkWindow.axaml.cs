using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class FullscreenArtworkWindow : Window
{
    public FullscreenArtworkWindow()
    {
        
    }
    
    public FullscreenArtworkWindow(string filePath)
    {
        InitializeComponent();

        DataContext = new FullscreenArtworkWindowViewModel()
        {
            Filepath = filePath
        };
        
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}