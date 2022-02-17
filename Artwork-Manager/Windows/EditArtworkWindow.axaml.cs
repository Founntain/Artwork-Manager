using ArtworkManager.Classes;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class EditArtworkWindow : Window
{
    private DatabaseContext _ctx = new DatabaseContext();
    
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

        DataContext = new EditArtworkWindowViewModel(this, artwork, _ctx);
        
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

    private void Window_OnClosed(object? sender, EventArgs e)
    {
        _ctx.Dispose();
    }
}