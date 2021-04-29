using MediatR;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDeveloperDetail
{
    public class GetGameDeveloperDetailQuery : IRequest<GameDeveloperDetailVm>
    {
        public int Id { get; set; }
    }
}
