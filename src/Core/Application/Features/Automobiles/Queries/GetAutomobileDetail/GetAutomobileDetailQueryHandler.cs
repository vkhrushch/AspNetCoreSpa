using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail
{
    public class GetAutomobileDetailQueryHandler : IRequestHandler<GetAutomobileDetailQuery, AutomobileDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetAutomobileDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AutomobileDetailVm> Handle(GetAutomobileDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Automobiles
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Automobile), request.Id);
            }

            return _mapper.Map<AutomobileDetailVm>(entity);
        }
    }
}
