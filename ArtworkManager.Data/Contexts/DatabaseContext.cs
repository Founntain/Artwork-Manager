using ArtworkManager.Data.Configurations;
using ArtworkManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtworkManager.Data.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; } = null!;
    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Collection> Collections { get; set; } = null!;
    public DbSet<SocialMedia> SocialMediae { get; set; } = null!;
    
    public DatabaseContext(bool cleanDb = false) : base()
    {
        if(cleanDb)
            Database.EnsureDeleted();
        
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=data/artwork-manager.db");
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArtworkConfirguration());
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new CollectionConfiguration());
    }
}