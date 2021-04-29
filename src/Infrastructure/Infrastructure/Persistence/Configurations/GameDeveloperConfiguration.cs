using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameDeveloperConfiguration : IEntityTypeConfiguration<GameDeveloper>
    {
        public void Configure(EntityTypeBuilder<GameDeveloper> builder)
        {
            builder.Property(e => e.GameDeveloperId);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Age);

            builder.HasOne(e => e.DeveloperLevel)
                .WithMany(dl => dl.DevelopersOfLevel)
                .HasForeignKey(gd => gd.DeveloperLevelId)
                .HasConstraintName("FK_GameDevelopers_GameDeveloperLevels");
        }
    }
}
