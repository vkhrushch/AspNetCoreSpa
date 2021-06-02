using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class ChatRoomConfiguration : IEntityTypeConfiguration<ChatRoom>
    {
        public void Configure(EntityTypeBuilder<ChatRoom> builder)
        {
            builder.Property(e => e.ChatRoomId);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
