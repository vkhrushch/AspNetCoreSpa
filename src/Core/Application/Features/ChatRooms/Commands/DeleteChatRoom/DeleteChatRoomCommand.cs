using MediatR;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Commands.DeleteChatRoom
{
    public class DeleteChatRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
