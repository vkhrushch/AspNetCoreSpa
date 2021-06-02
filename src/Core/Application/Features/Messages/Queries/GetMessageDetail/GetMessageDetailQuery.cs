using MediatR;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageDetail
{
    public class GetMessageDetailQuery : IRequest<MessageDetailVm>
    {
        public int Id { get; set; }
    }
}
