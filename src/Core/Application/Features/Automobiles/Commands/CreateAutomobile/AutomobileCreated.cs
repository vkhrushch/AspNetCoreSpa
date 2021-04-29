using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.CreateAutomobile
{
    public class AutomobileCreated : INotification
    {
        public string AutomobileId { get; set; }

        public class CarExpertCreatedHandler : INotificationHandler<AutomobileCreated>
        {
            private readonly IEmailService _email;

            public CarExpertCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(AutomobileCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
