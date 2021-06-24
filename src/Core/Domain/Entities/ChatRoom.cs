using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Domain.Entities
{
    public class ChatRoom
    {
        [Key]
        public int ChatRoomId { get; set; }
        public string Name { get; set; }
    }
}
