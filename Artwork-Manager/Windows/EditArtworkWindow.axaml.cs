using ArtworkManager.Classes;
using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class EditArtworkWindow : Window
{
    public EditArtworkWindow()
    {
        InitializeComponent();
        
        #if DEBUG
                this.AttachDevTools();
        #endif
    }
    
    public EditArtworkWindow(Artwork artwork)
    {
        InitializeComponent();

        DataContext = new EditArtworkWindowViewModel(this, artwork);
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void Window_OnActivated(object? sender, EventArgs e)
    {
        var vm = (EditArtworkWindowViewModel) DataContext;
    }

    private void Image_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        var vm = (EditArtworkWindowViewModel) DataContext;
        
        var x = new FullscreenArtworkWindow(vm.Artwork.Filepath).ShowDialog(this);
    }
}