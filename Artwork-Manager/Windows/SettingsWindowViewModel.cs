using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using ArtworkManager.Database.Contexts;
using ArtworkManager.Database.Entities;
using Avalonia.Controls;

namespace ArtworkManager.ViewModels;

public class SettingsWindowBaseViewModel : BaseViewModel
{
    private string dbLocationText;
    
    public string DbLocationText
    {
        get => dbLocationText;
        set
        {
            dbLocationText = value;
            OnPropertyChanged();
        }
    }

    public async void CreateTestDataCommand()
    {
        await CreateArtists();
        
        using (var ctx = new DatabaseContext())
        {

            var character = new Character
            {
                Name = "Founntain",
                Description = "Test Description"
            };

            await ctx.Characters.AddAsync(character);

            await ctx.SaveChangesAsync();
            
            var files = Directory.GetFiles(@"Z:\Alles\Founntain\Fertiges", "*.*", SearchOption.AllDirectories)
                .Where(x => x.EndsWith(".png") || x.EndsWith(".jpg") || x.EndsWith(".jpeg"));
            
            foreach (var file in files)
            {
                var art = new Artwork
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Description = $"Description - {Guid.NewGuid()}",
                    Filepath = file
                };

                art.Characters.Add(character);

                await ctx.Artworks.AddAsync(art);
            }
            
            await ctx.SaveChangesAsync();
        }
    }

    private async Task CreateArtists()
    {
        using (var ctx = new DatabaseContext())
        {
            var directories =
                Directory.GetDirectories(@"Z:\Alles\Founntain\Fertiges", "*", SearchOption.TopDirectoryOnly);

            await ctx.Artists.AddRangeAsync(directories.Select(x => new Artist
            {
                Name = Path.GetFileName(x)
            }).ToList());

            await ctx.SaveChangesAsync();
        }
    }
}