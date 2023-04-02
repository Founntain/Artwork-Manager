using ArtworkManager.Data.Enums;

namespace ArtworkManager.Data.Entities;

public class Artwork : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string Filepath { get; set; } = null!;

    public ArtworkType ArtworkType { get; set; }
    public ArtworkAcquiredType ArtworkAcquiredType { get; set; }
    
    public bool IsNsfw { get; set; }

    public virtual ISet<Character> Characters { get; set; } = new HashSet<Character>();
    public virtual ISet<Artist> Artists { get; set; } = new HashSet<Artist>();
    public virtual ISet<Collection> Collections { get; set; } = new HashSet<Collection>();

    public override string ToString() => Name;
}