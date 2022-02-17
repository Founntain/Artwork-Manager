using ArtworkManager.Database.Entities;

namespace ArtworkManager.Classes;

public class AdvancedArtwork : Artwork
{
    public string IdString => $"ID: {Id}";
    public string CreationTimeString => $"Creation time: {CreationTime}";

    public ICollection<string> ArtworkTypeStrings { get; set; } = new List<string>
    {
        "Image",
        "Gif",
        "Video",
        "Other"
    };

    public ICollection<string> ArtworkAcquiredTypeStrings { get; set; } = new List<string>
    {
        "Commission",
        "YCH",
        "Gift",
        "Raffle"
    };

    public AdvancedArtwork()
    {
        
    }

    public AdvancedArtwork(Artwork artwork)
    {
        Id = artwork.Id;
        CreationTime = artwork.CreationTime;
        Name = artwork.Name;
        Description = artwork.Description;
        Filepath = artwork.Filepath;
        ArtworkType = artwork.ArtworkType;
        ArtworkAcquiredType = artwork.ArtworkAcquiredType;
        IsNsfw = artwork.IsNsfw;

        Artists = artwork.Artists;
        Characters = artwork.Characters;
    }
}