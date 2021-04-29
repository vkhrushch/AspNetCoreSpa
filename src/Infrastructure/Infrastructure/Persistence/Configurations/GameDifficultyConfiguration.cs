using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameDifficultyConfiguration : IEntityTypeConfiguration<GameDifficultyLevel>
    {
        public void Configure(EntityTypeBuilder<GameDifficultyLevel> builder)
        {
            builder.Property(e => e.GameDifficultyLevelId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
