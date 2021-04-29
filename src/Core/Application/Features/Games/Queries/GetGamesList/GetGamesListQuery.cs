using MediatR;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGamesList
{
    public class GetGamesListQuery : IRequest<GamesListVm>
    {
    }
}
