using System.Collections.ObjectModel;
using ArtworkManager.Classes;
using ArtworkManager.Database.Entities;

namespace ArtworkManager.ViewModels;

public class ArtworkBrowserBaseViewModel : BaseViewModel
{
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
}