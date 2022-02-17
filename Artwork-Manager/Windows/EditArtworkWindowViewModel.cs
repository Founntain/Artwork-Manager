using System.Threading.Tasks;
using ArtworkManager.Classes;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.Enums;
using Avalonia.Controls;

namespace ArtworkManager.ViewModels;

public class EditArtworkWindowViewModel : BaseViewModel
{
    private readonly DatabaseContext _ctx;
    private readonly Window _window;

    private ICollection<Artist> _artists;

    private AdvancedArtwork _artwork;
    private ICollection<Character> _characters;
    private ArtworkType _selectedArtworkType;

    public EditArtworkWindowViewModel(Window window, Artwork artwork, DatabaseContext ctx)
    {
        _window = window;
        Artwork = new AdvancedArtwork(artwork);

        _ctx = ctx;

        Characters = _ctx.Characters.ToList();
        Artists = _ctx.Artists.ToList();
    }

    public AdvancedArtwork Artwork
    {
        get => _artwork;
        set
        {
            _artwork = value;
            OnPropertyChanged();
        }
    }

    public ArtworkType SelectedArtworkType
    {
        get => _selectedArtworkType;
        set
        {
            _selectedArtworkType = value;
            OnPropertyChanged();
        }
    }

    public IEnumerable<ArtworkType> ArtworkTypes => Enum.GetValues<ArtworkType>();

    public IEnumerable<ArtworkAcquiredType> ArtworkAcquieredTypes => Enum.GetValues<ArtworkAcquiredType>();

    public ICollection<Character> Characters
    {
        get => _characters;
        set
        {
            _characters = value;
            OnPropertyChanged();
        }
    }

    public ICollection<Artist> Artists
    {
        get => _artists;
        set
        {
            _artists = value;
            OnPropertyChanged();
        }
    }

    public async Task OnSaveCommand()
    {
        var artwork = _ctx.Artworks.FirstOrDefault(x => x.Id == Artwork.Id);

        if (artwork == null) return;

        artwork.Name = Artwork.Name;
        artwork.Description = Artwork.Description;
        artwork.Filepath = Artwork.Filepath;
        artwork.ArtworkType = Artwork.ArtworkType;
        artwork.ArtworkAcquiredType = Artwork.ArtworkAcquiredType;
        artwork.IsNsfw = Artwork.IsNsfw;

        await _ctx.SaveChangesAsync();


        _window.Close();
    }

    public async Task OnChangeFilepathCommand()
    {
        var dialog = new OpenFileDialog();

        dialog.AllowMultiple = false;

        var result = await dialog.ShowAsync(_window);

        var path = result.FirstOrDefault();

        Artwork.Filepath = path;

        Artwork = new AdvancedArtwork(Artwork);
    }
}