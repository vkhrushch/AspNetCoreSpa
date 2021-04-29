using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;

namespace AspNetCoreSpa.Application.Features.Games.Commands.CreateGame
{
    public class CreateGameCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDifficultyLevel Difficulty { get; set; }

        public class Handler : IRequestHandler<CreateGameCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateGameCommand request, CancellationToken cancellationToken)
            {
                var entity = new Game
                {
                    GameId = request.Id,
                    Name = request.Name,
                    DifficultyLevel = request.Difficulty
                };

                _context.Games.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new GameCreated { GameId = entity.GameId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
