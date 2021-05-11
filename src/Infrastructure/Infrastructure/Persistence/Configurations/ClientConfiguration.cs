using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(e => e.ClientId)
                .HasMaxLength(7)
                .ValueGeneratedNever();

            builder.Property(e => e.FirstName).HasMaxLength(60);

            builder.Property(e => e.LastName).HasMaxLength(60);            
        }
    }
}
