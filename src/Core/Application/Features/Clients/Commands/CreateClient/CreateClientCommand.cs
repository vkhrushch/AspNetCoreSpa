using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;

namespace AspNetCoreSpa.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class Handler : IRequestHandler<CreateClientCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var entity = new Client
                {
                    ClientId = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                _context.Clients.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new ClientCreated { ClientId = entity.ClientId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
