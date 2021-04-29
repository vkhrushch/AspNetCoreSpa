using System.Collections.Generic;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGamesList
{
    public class GamesListVm
    {
        public IList<GameDto> Games { get; set; }
    }
}
