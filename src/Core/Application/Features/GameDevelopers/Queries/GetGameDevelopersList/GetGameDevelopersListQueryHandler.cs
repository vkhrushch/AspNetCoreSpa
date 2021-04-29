using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDevelopersList
{
    public class GetGameDevelopersListQueryHandler : IRequestHandler<GetGameDevelopersListQuery, GameDevelopersListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetGameDevelopersListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GameDevelopersListVm> Handle(GetGameDevelopersListQuery request, CancellationToken cancellationToken)
        {
            var gameDevelopers = await _context.GameDevelopers
                .ProjectTo<GameDeveloperDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new GameDevelopersListVm
            {
                GameDevelopers = gameDevelopers
            };

            return vm;
        }
    }
}
