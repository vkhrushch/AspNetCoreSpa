using MediatR;

namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientDetail
{
    public class GetClientDetailQuery : IRequest<ClientDetailVm>
    {
        public string Id { get; set; }
    }
}
