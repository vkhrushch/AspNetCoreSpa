using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.CreateAutomobile
{
    public class CreateAutomobileCommand : IRequest
    {
        public AutomobileLookupDto Auto { get; set; }

        public class Handler : IRequestHandler<CreateAutomobileCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateAutomobileCommand request, CancellationToken cancellationToken)
            {
               var nextId = _context.Automobiles.Max(i => i.AutomobileId) + 1;
                var entity = new Automobile
                {
                    AutomobileId = nextId,
                    ClientId = request.Auto.ClientId,
                    CarExpertId = request.Auto.CarExpertId,
                    Brand = request.Auto.Brand,
                    Color = request.Auto.Color,
                    Model = request.Auto.Model,
                    PlateNumber = request.Auto.PlateNumber,
                    Year = request.Auto.Year,
                };

                _context.Automobiles.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AutomobileCreated { AutomobileId = entity.AutomobileId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
