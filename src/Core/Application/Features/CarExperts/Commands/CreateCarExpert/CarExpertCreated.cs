using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.CarExperts.Commands.CreateCarExpert
{
    public class CarExpertCreated : INotification
    {
        public string CarExpertId { get; set; }

        public class CarExpertCreatedHandler : INotificationHandler<CarExpertCreated>
        {
            private readonly IEmailService _email;

            public CarExpertCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(CarExpertCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
