using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Notifications.Models;
using MediatR;

namespace AspNetCoreSpa.Application.Features.Games.Commands.CreateGame
{
    public class GameCreated : INotification
    {
        public int GameId { get; set; }

        public class GameCreatedHandler : INotificationHandler<GameCreated>
        {
            private readonly IEmailService _email;

            public GameCreatedHandler(IEmailService email)
            {
                _email = email;
            }

            public async Task Handle(GameCreated notification, CancellationToken cancellationToken)
            {
                await _email.SendCustomerCreatedEmail(new EmailMessage());
            }
        }
    }
}
