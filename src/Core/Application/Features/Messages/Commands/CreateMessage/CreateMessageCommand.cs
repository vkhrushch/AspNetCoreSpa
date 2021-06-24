using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace AspNetCoreSpa.Application.Features.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string MessageTime { get; set; }
        public class Handler : IRequestHandler<CreateMessageCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;
            //private readonly IUserManager _userManager;
            private readonly ICurrentUserService _currentUser;

            public Handler(IApplicationDbContext context, IMediator mediator/*, IUserManager userManager*/, ICurrentUserService currentUser)
            {
                _context = context;
                _mediator = mediator;
                /*_userManager = userManager;*/
                _currentUser = currentUser;
            }

            public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {
                var entity = new Message
                {
                    MessageId = request.Id,
                    ChatRoomId = request.ChatRoomId,
                    UserName = request.UserName,
                    MessageTime = request.MessageTime,
                    Text = request.Text,
                    UserId= request.UserId
                };

                _context.Messages.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new MessageCreated { MessageId = entity.MessageId }, cancellationToken);

                return entity.MessageId;
            }
        }
    }
}
