namespace ArtworkManager.Data.Entities;

public class Character : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ISet<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
}