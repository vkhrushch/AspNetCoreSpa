using MediatR;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail
{
    public class GetAutomobileDetailQuery : IRequest<AutomobileDetailVm>
    {
        public string Id { get; set; }
    }
}
