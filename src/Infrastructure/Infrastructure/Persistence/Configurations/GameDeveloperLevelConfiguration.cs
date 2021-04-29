using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameDeveloperLevelConfiguration : IEntityTypeConfiguration<GameDeveloperLevel>
    {
        public void Configure(EntityTypeBuilder<GameDeveloperLevel> builder)
        {
            builder.Property(e => e.GameDeveloperLevelId);

            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
