using System.Collections.ObjectModel;
using ArtworkManager.Classes;
using ArtworkManager.Database.Entities;
using ArtworkManager.Windows;
using Avalonia.Controls;

namespace ArtworkManager.ViewModels;

public class ArtworkBrowserBaseViewModel : BaseViewModel
{
    private Window _window;
    private ObservableCollection<Artwork> _artworks;
    private Artwork _selectedArtwork;

    public ObservableCollection<Artwork> Artworks
    {
        get => _artworks;
        set
        {
            _artworks = value;
            OnPropertyChanged();
        }
    }

    public Artwork SelectedArtwork
    {
        get => _selectedArtwork;
        set
        {
            _selectedArtwork = value;
            OnPropertyChanged();
        }
    }

    public ArtworkBrowserBaseViewModel(Window window)
    {
        _window = window;
    }

    public void OpenFullscreenCommand()
    {
        new FullscreenArtworkWindow(SelectedArtwork.Filepath).Show();
    }

    public void EditArtworkCommand()
    {
        new EditArtworkWindow(SelectedArtwork).ShowDialog(_window);
    }
}