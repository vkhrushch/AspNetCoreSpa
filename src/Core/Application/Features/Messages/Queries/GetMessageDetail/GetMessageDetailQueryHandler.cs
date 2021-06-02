using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageDetail
{
    public class GetMessageDetailQueryHandler : IRequestHandler<GetMessageDetailQuery, MessageDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetMessageDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MessageDetailVm> Handle(GetMessageDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Messages
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            return _mapper.Map<MessageDetailVm>(entity);
        }
    }
}
