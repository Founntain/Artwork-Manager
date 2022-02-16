using ArtworkManager.Database.Configurations;
using ArtworkManager.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtworkManager.Database.Contexts;

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
        optionsBuilder.UseSqlite("Data Source=artwork-manager.db");
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