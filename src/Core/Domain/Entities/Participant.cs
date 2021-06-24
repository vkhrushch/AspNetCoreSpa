using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Participant
    {
        public int ParticipantId;

        [ForeignKey("ChatRoomId")]
        public int ChatRoomId;

        public Guid UserId;
    }
}
