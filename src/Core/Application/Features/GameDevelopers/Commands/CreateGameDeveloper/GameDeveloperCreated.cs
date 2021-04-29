using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;
using MediatR;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Commands.CreateGameDeveloper
{
    class GameDeveloperCreated : INotification
    {
        public int GameDeveloperId { get; set; }

        public class GameDeveloperCreatedHandler : INotificationHandler<GameDeveloperCreated>
        {
            private readonly IEmailService _email;

            public GameDeveloperCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(GameDeveloperCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
