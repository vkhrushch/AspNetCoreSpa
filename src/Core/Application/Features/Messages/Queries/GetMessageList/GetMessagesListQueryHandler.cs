using AspNetCoreSpa.Application.Abstractions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList
{
    public class GetMessagesListQueryHandler : IRequestHandler<GetMessageListQuery, MessageListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMessagesListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<MessageListVm> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            var messages = await _context.Messages
                .ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new MessageListVm
            {
                Messages = messages
            };

            return vm;
        }
    }
}
