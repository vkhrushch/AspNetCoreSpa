using MediatR;

namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientsListQuery : IRequest<ClientsListVm>
    {
    }
}
