using System.Collections.ObjectModel;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class ArtworkBrowser : Window
{
    private DatabaseContext _ctx;
    
    public ArtworkBrowser()
    {
        InitializeComponent();

        _ctx = new DatabaseContext();

        DataContext = new ArtworkBrowserBaseViewModel();

        var vm = (ArtworkBrowserBaseViewModel) DataContext;

        vm.Artworks = new ObservableCollection<Artwork>(GetArtworks());
        
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private IEnumerable<Artwork> GetArtworks()
    {
        return _ctx.Artworks.ToList();
    }
    
    private async void WindowBase_OnActivated(object? sender, EventArgs e)
    {
       
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var vm = (ArtworkBrowserBaseViewModel) DataContext;

        var value = (((ListBox) sender).SelectedItem as Artwork);

        if (value == null) return;
        
        vm.SelectedArtwork = value;
    }

    private async void WindowBase_OnClosed(object? sender, EventArgs e)
    {
        await _ctx.DisposeAsync();
    }
}