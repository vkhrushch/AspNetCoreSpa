using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(e => e.GameId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.DifficultyLevel)
                .WithMany(gd => gd.GamesOfDifficultyLevel)
                .HasForeignKey(g => g.GameDifficultyLevelId)
                .HasConstraintName("FK_Games_GameDifficultyLevels");
        }
    }
}
