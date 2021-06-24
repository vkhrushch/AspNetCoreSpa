using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSpa.Web.SignalR
{
    public class Chat : Hub
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public Chat(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            
        public Task Send(string message)
        {
            return Clients.All.SendAsync("Send", message);
        }

        public Task SendMessage(int messageId)
        {
            var message = _context.Messages.ProjectTo<MessageLookupDto>(_mapper.ConfigurationProvider).FirstOrDefault(i => i.MessageId == messageId);
            return Clients.All.SendAsync("SendMessage", message);
        }
    }
}