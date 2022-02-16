using ArtworkManager.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtworkManager.Database.Configurations;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Artworks).WithMany(x => x.Characters);
    }
}