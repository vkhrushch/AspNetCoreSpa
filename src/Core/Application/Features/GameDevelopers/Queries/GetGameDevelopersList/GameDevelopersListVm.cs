using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDevelopersList
{
    public class GameDevelopersListVm
    {
        public IList<GameDeveloperDto> GameDevelopers { get; set; }
    }
}
