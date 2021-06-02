using MediatR;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomDetail
{
    public class GetChatRoomDetailQuery : IRequest<ChatRoomDetailVm>
    {
        public int Id { get; set; }
    }
}
