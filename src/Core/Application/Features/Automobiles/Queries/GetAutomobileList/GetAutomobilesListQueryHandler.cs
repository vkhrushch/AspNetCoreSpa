using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList
{
    public class GetAutomobilesListQueryHandler : IRequestHandler<GetAutomobilesListQuery, AutomobilesListVm>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAutomobilesListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AutomobilesListVm> Handle(GetAutomobilesListQuery request, CancellationToken cancellationToken)
        {
            var automobiles = await _context.Automobiles
                .ProjectTo<AutomobileLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new AutomobilesListVm
            {
                Automobiles = automobiles
            };

            return vm;
        }
    }
}
