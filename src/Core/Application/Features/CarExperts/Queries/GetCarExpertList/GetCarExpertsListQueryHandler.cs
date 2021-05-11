using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertList
{
    public class GetCarExpertsListQueryHandler : IRequestHandler<GetCarExpertsListQuery, CarExpertsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCarExpertsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CarExpertsListVm> Handle(GetCarExpertsListQuery request, CancellationToken cancellationToken)
        {
            var carExperts = await _context.CarExperts
                .ProjectTo<CarExpertLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CarExpertsListVm
            {
                CarExperts = carExperts
            };

            return vm;
        }
    }
}
