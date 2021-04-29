using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Application.Features.Games.Commands.UpdateGame
{
    public class UpdateGameCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDifficultyLevel Difficulty { get; set; }

        public class Handler : IRequestHandler<UpdateGameCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Games
                    .SingleOrDefaultAsync(c => c.GameId == request.Id, cancellationToken);

                if(entity == null)
                {
                    throw new NotFoundException(nameof(Game), request.Id);
                }

                entity.Name = request.Name;
                entity.DifficultyLevel = request.Difficulty;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
