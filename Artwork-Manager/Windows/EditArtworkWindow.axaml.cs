using ArtworkManager.Classes;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ArtworkManager.Windows;

public class EditArtworkWindow : Window
{
    private readonly DatabaseContext _ctx = new();

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
    
    public EditArtworkWindow(string artworkPath)
    {
        InitializeComponent();

        DataContext = new EditArtworkWindowViewModel(this, artworkPath, _ctx, false);

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
        var vm = (EditArtworkWindowViewModel) DataContext!;
    }

    private void Image_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        var vm = (EditArtworkWindowViewModel) DataContext!;

        new FullscreenArtworkWindow(vm.Artwork.Filepath).ShowDialog(this);
    }

    private void Window_OnClosed(object? sender, EventArgs e)
    {
        _ctx.Dispose();
    }

    private void AddCharacter_OnClick(object? sender, RoutedEventArgs e)
    {
        var character = ((Button) sender!).DataContext as Character;
        var vm = (EditArtworkWindowViewModel) DataContext!;

        if (character == null) return;

        // var artwork = _ctx.Artworks.FirstOrDefault(x => x.Id == vm.Artwork.Id);
        //
        // artwork.Characters.Add(character);
        //
        // _ctx.SaveChanges();
        //
        // vm.Artwork = new AdvancedArtwork(artwork);

        vm.Artwork.Characters.Add(character);
    }

    private void RemoveCharacter_OnClick(object? sender, RoutedEventArgs e)
    {
        var character = ((Button) sender!).DataContext as Character;
        var vm = (EditArtworkWindowViewModel) DataContext!;
        
        if (character == null) return;
        
        // var artwork = _ctx.Artworks.FirstOrDefault(x => x.Id == vm.Artwork.Id);
        //
        // artwork.Characters.Remove(character);
        //
        // _ctx.SaveChanges();
        //
        // vm.Artwork = new AdvancedArtwork(artwork);

        vm.Artwork.Characters.Remove(character);
    }

    private void AddArtist_OnClick(object? sender, RoutedEventArgs e)
    {
        var artist = ((Button) sender!).DataContext as Artist;
        var vm = (EditArtworkWindowViewModel) DataContext!;
        
        if (artist == null) return;
        
        // var artwork = _ctx.Artworks.FirstOrDefault(x => x.Id == vm.Artwork.Id);
        //
        // artwork.Artists.Add(artist);
        //
        // _ctx.SaveChanges();
        //
        // vm.Artwork = new AdvancedArtwork(artwork);

        vm.Artwork.Artists.Add(artist);
    }

    private void RemoveArtist_OnClick(object? sender, RoutedEventArgs e)
    {
        var artist = ((Button) sender!).DataContext as Artist;
        var vm = (EditArtworkWindowViewModel) DataContext!;

        if (artist == null) return;
        
        // var artwork = _ctx.Artworks.FirstOrDefault(x => x.Id == vm.Artwork.Id);
        //
        // artwork.Artists.Add(artist);
        //
        // _ctx.SaveChanges();
        //
        // vm.Artwork = new AdvancedArtwork(artwork);
        
        vm.Artwork.Artists.Remove(artist);
    }
}