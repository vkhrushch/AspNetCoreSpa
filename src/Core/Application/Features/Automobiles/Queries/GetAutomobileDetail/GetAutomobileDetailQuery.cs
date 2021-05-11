using MediatR;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail
{
    public class GetAutomobileDetailQuery : IRequest<AutomobileDetailVm>
    {
        public int Id { get; set; }
    }
}
