using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertDetail
{
    public class GetCarExpertDetailQueryHandler : IRequestHandler<GetCarExpertDetailQuery, CarExpertDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetCarExpertDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CarExpertDetailVm> Handle(GetCarExpertDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.CarExperts
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CarExpert), request.Id);
            }

            return _mapper.Map<CarExpertDetailVm>(entity);
        }
    }
}
