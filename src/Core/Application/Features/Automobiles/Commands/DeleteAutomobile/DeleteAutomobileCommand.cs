using MediatR;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.DeleteAutomobile
{
    public class DeleteAutomobileCommand : IRequest
    {
        public string Id { get; set; }
    }
}
