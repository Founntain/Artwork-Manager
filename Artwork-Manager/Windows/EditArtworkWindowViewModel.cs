using System.Diagnostics;
using System.Threading.Tasks;
using ArtworkManager.Classes;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using ArtworkManager.Enums;
using Avalonia;
using Avalonia.Controls;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArtworkManager.ViewModels;

public class EditArtworkWindowViewModel : BaseViewModel
{
    private Window Window;
    
    private AdvancedArtwork _artwork;
    private ArtworkType _selectedArtworkType;

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

    public IEnumerable<ArtworkType> ArtworkTypes
    {
        get
        {
            return Enum.GetValues<ArtworkType>();
        }
    }
    
    public IEnumerable<ArtworkAcquiredType> ArtworkAcquieredTypes
    {
        get
        {
            return Enum.GetValues<ArtworkAcquiredType>();
        }
    }

    public EditArtworkWindowViewModel(Window window, Artwork artwork)
    {
        Window = window;
        Artwork = new AdvancedArtwork(artwork);
    }

    public async Task OnSaveCommand()
    {
        using (var ctx = new DatabaseContext())
        {
            var artwork = ctx.Artworks.FirstOrDefault(x => x.Id == Artwork.Id);

            if (artwork == null) return;

            artwork.Name = Artwork.Name;
            artwork.Description = Artwork.Description;
            artwork.Filepath = Artwork.Filepath;
            artwork.ArtworkType = Artwork.ArtworkType;
            artwork.ArtworkAcquiredType = Artwork.ArtworkAcquiredType;
            artwork.IsNsfw = Artwork.IsNsfw;

            await ctx.SaveChangesAsync();
        }
        
        Window.Close();
    }

    public async Task OnChangeFilepathCommand()
    {
        var dialog = new OpenFileDialog();

        dialog.AllowMultiple = false;

        var result = await dialog.ShowAsync(Window);

        var path = result.FirstOrDefault();

        Artwork.Filepath = path;

        Artwork = new AdvancedArtwork(Artwork);
    }
}