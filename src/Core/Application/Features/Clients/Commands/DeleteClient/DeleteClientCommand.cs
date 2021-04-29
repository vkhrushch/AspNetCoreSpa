using MediatR;

namespace AspNetCoreSpa.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public string Id { get; set; }
    }
}
