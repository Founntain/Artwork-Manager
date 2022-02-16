namespace ArtworkManager.Database.Entities;

public class SocialMedia : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Url { get; set; } = null!;
}