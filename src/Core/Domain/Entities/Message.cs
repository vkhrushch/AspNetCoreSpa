using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int ChatRoomId { get; set; }
        public string UserName { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
        public string MessageTime { get; set; }
    }
}
