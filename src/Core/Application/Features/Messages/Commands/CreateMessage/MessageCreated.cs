using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;


namespace AspNetCoreSpa.Application.Features.Messages.Commands.CreateMessage
{
    public class MessageCreated : INotification
    {
        public int MessageId { get; set; }
        public class MessageCreatedHandler : INotificationHandler<MessageCreated>
        {
            private readonly IEmailService _email;

            public MessageCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(MessageCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
