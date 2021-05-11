using MediatR;

namespace AspNetCoreSpa.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }
    }
}
