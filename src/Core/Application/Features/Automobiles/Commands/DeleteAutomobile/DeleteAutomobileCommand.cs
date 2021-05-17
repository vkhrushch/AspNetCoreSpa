using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.DeleteAutomobile
{
    public class DeleteAutomobileCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteAutomobileCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteAutomobileCommand request, CancellationToken cancellationToken)
            {               
                var auto = _context.Automobiles.FirstOrDefault(i => i.AutomobileId == request.Id);
                _context.Automobiles.Remove(auto);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
