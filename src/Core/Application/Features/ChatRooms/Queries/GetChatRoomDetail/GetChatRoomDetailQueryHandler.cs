using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomDetail
{
    public class GetChatRoomDetailQueryHandler : IRequestHandler<GetChatRoomDetailQuery, ChatRoomDetailVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetChatRoomDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ChatRoomDetailVm> Handle(GetChatRoomDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ChatRooms
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ChatRoom), request.Id);
            }

            return _mapper.Map<ChatRoomDetailVm>(entity);
        }
    }
}
