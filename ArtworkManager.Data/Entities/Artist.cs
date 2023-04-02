namespace ArtworkManager.Data.Entities;

public class Artist : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ISet<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
}