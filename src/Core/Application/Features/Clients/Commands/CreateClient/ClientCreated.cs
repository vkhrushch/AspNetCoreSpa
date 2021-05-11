using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Clients.Commands.CreateClient
{
    public class ClientCreated : INotification
    {
        public int ClientId { get; set; }

        public class CustomerCreatedHandler : INotificationHandler<ClientCreated>
        {
            private readonly IEmailService _email;

            public CustomerCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(ClientCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
