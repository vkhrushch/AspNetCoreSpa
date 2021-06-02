using AspNetCoreSpa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Infrastructure.Persistence.Configurations
{
    public class ParticipantConfiguration : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.Property(e => e.ParticipantId);

            builder.Property(e => e.ChatRoomId);

            builder.Property(e => e.UserId)
                .IsRequired();
        }
    }
}
