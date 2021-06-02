using MediatR;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListVm>
    {
        public int RoomId { get; set; }
    }
}
