using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientList
{
    public class GetClientsListQueryHandler : IRequestHandler<GetClientsListQuery, ClientsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientsListVm> Handle(GetClientsListQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Clients
                .ProjectTo<ClientLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new ClientsListVm
            {
                Clients = customers
            };

            return vm;
        }
    }
}
