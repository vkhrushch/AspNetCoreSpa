using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class Handler : IRequestHandler<UpdateClientCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Clients
                    .SingleOrDefaultAsync(c => c.ClientId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Client), request.Id);
                }

                entity.FirstName = request.FirstName;
                entity.LastName = request.LastName;
               

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
