using MediatR;
using System;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomList
{
    public class GetChatRoomsListQuery : IRequest<ChatRoomsListVm>
    {
        public Guid UserId { get; set; }
    }
}
