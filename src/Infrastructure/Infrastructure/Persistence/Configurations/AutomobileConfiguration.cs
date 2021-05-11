using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class AutomobileConfiguration : IEntityTypeConfiguration<Automobile>
    {
        public void Configure(EntityTypeBuilder<Automobile> builder)
        {
            builder.Property(e => e.AutomobileId)
                .HasMaxLength(7)
                .ValueGeneratedNever();

            builder.Property(e => e.Brand).HasMaxLength(60);

            builder.Property(e => e.CarExpertId).HasMaxLength(60);

            builder.Property(e => e.Color).HasMaxLength(60);

            builder.Property(e => e.ClientId).HasMaxLength(60);

            builder.Property(e => e.Model).HasMaxLength(60);

            builder.Property(e => e.PlateNumber).HasMaxLength(60);

            builder.Property(e => e.Year).HasMaxLength(60);
        }
    }
}
