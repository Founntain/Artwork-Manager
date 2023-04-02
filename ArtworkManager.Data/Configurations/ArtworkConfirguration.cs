using ArtworkManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtworkManager.Data.Configurations;

public class ArtworkConfirguration : IEntityTypeConfiguration<Artwork>
{
    public void Configure(EntityTypeBuilder<Artwork> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Characters).WithMany(x => x.Artworks);
        builder.HasMany(x => x.Artists).WithMany(x => x.Artworks);
    }
}