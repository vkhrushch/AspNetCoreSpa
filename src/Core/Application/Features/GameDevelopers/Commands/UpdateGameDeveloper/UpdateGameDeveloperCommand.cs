using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper
{
    public class UpdateGameDeveloperCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GameDeveloperLevel DeveloperLevel { get; set; }

        public class Handler : IRequestHandler<UpdateGameDeveloperCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGameDeveloperCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.GameDevelopers
                    .SingleOrDefaultAsync(c => c.GameDeveloperId == request.Id, cancellationToken);

                if(entity == null)
                {
                    throw new NotFoundException(nameof(GameDeveloper), request.Id);
                }

                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
                entity.Age = request.Age;
                entity.DeveloperLevel = request.DeveloperLevel;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
