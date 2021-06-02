using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Commands.CreateChatRoom
{
    public class ChatRoomCreated : INotification
    {
        public int ChatRoomId { get; set; }
        public class ChatRoomCreatedHandler : INotificationHandler<ChatRoomCreated>
        {
            private readonly IEmailService _email;

            public ChatRoomCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(ChatRoomCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
