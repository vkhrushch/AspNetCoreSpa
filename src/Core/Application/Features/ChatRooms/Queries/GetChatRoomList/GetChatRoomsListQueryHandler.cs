using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Extensions;
using AspNetCoreSpa.Application.Features.Participants.Queries.GetParticipantList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomList
{
    public class GetChatRoomsListQueryHandler : IRequestHandler<GetChatRoomsListQuery, ChatRoomsListVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChatRoomsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ChatRoomsListVm> Handle(GetChatRoomsListQuery request, CancellationToken cancellationToken)
        {
            var chatRooms = await _context.ChatRooms
                .ProjectTo<ChatRoomLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var participants = await _context.Participants
                .ProjectTo<ParticipantLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
           
            var vm = new ChatRoomsListVm
            {
                ChatRooms = chatRooms.Where(t => participants.Where(k => k.UserId.ToGuid() == request.UserId).ToList().Select(i => i.ChatRoomId).Contains(t.RoomId)).ToList()
            };

            return vm;
        }
    }
}
