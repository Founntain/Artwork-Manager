namespace ArtworkManager.Database.Entities;

public class Collection : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    
    public virtual ISet<Artwork> Artworks { get; set; }
}