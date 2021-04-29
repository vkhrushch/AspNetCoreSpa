using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameFeatureConfiguration : IEntityTypeConfiguration<GameFeature>
    {
        public void Configure(EntityTypeBuilder<GameFeature> builder)
        {
            builder.Property(e => e.GameFeatureId);

            builder.HasOne(e => e.Game)
                .WithMany(g => g.FeaturesInDevelopment)
                .HasForeignKey(gf => gf.GameId)
                .HasConstraintName("FK_GameFeatures_Games");

            builder.HasOne(e => e.Developer)
                .WithMany(g => g.GameFeaturesAssigned)
                .HasForeignKey(gf => gf.DeveloperId)
                .HasConstraintName("FK_GameFeatures_GameDevelopers");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(e => e.DevelopmentState)
                .WithMany(gf => gf.FeaturesInState)
                .HasForeignKey(gf => gf.DevelopmentStateId)
                .HasConstraintName("FK_GameFeatures_DevelopmentStates");
        }
    }
}
