using MediatR;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDevelopersList
{
    public class GetGameDevelopersListQuery : IRequest<GameDevelopersListVm>
    {
    }
}
