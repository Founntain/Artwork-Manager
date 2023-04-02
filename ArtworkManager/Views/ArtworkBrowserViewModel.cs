using System.Collections.ObjectModel;
using System.Reactive.Disposables;
using ArtworkManager.Data.Contexts;
using ArtworkManager.Data.Entities;
using Nein.Base;
using Nein.Extensions;
using ReactiveUI;

namespace ArtworkManager.Views;

public class ArtworkBrowserViewModel : BaseViewModel
{
    private ObservableCollection<Artwork> _artworks;
    private Artwork _selectedArtwork;

    public Artwork SelectedArtwork
    {
        get => _selectedArtwork;
        set => this.RaiseAndSetIfChanged(ref _selectedArtwork, value);
    }

    public ArtworkBrowserViewModel()
    {
        Activator = new ViewModelActivator();
        this.WhenActivated(Block);
    }

    private async void Block(CompositeDisposable obj)
    {
        await using (var context = new DatabaseContext())
        {
            Artworks = context.Artworks.ToObservableCollection();
        }
    }

    public ObservableCollection<Artwork> Artworks
    {
        get => _artworks;
        set => this.RaiseAndSetIfChanged(ref _artworks, value);
    }
}