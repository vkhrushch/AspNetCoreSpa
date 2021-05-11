using MediatR;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.DeleteAutomobile
{
    public class DeleteAutomobileCommand : IRequest
    {
        public int Id { get; set; }
    }
}
