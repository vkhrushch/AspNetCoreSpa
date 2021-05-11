using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class CarExpertConfiguration : IEntityTypeConfiguration<CarExpert>
    {
        public void Configure(EntityTypeBuilder<CarExpert> builder)
        {
            builder.Property(e => e.CarExpertId)
                .HasMaxLength(7)
                .ValueGeneratedNever();

            builder.Property(e => e.Name).HasMaxLength(60);

            builder.Property(e => e.Level).HasMaxLength(60);
        }
    }
}
