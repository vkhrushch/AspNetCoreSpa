using AspNetCoreSpa.Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class GameGenreGameConfiguration : IEntityTypeConfiguration<GameGenreGame>
    {
        public void Configure(EntityTypeBuilder<GameGenreGame> builder)
        {
            builder.HasKey(e => new
            {
                e.GameGenreId,
                e.GameId
            });

            builder.HasOne(e => e.GameGenre)
                .WithMany(gg => gg.GamesOfGenre)
                .HasForeignKey(e => e.GameGenreId);

            builder.HasOne(e => e.Game)
                .WithMany(g => g.Genres)
                .HasForeignKey(e => e.GameId);
        }
    }
}
