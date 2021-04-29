using MediatR;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertDetail
{
    public class GetCarExpertDetailQuery : IRequest<CarExpertDetailVm>
    {
        public string Id { get; set; }
    }
}
