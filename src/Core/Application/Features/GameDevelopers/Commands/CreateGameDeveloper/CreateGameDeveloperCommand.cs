using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Commands.CreateGameDeveloper
{
    public class CreateGameDeveloperCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GameDeveloperLevel DeveloperLevel { get; set; }

        public class Handler : IRequestHandler<CreateGameDeveloperCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateGameDeveloperCommand request, CancellationToken cancellationToken)
            {
                var entity = new GameDeveloper
                {
                    GameDeveloperId = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Age = request.Age,
                    DeveloperLevel = request.DeveloperLevel
                };

                _context.GameDevelopers.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new GameDeveloperCreated { GameDeveloperId = entity.GameDeveloperId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
