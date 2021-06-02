using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomList
{
    public class ChatRoomsListVm
    {
        public IList<ChatRoomLookupDto> ChatRooms { get; set; }
    }
}
