using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGamesList
{
    public class GetGamesListQueryHandler : IRequestHandler<GetGamesListQuery, GamesListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGamesListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GamesListVm> Handle(GetGamesListQuery request, CancellationToken cancellationToken)
        {
            var games = await _context.Games
                .ProjectTo<GameDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GamesListVm
            {
                Games = games
            };

            return vm;
        }
    }
}
