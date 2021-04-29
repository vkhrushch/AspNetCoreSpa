using MediatR;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGameDetail
{
    public class GetGameDetailQuery : IRequest<GameDetailVm>
    {
        public int Id { get; set; }
    }
}
