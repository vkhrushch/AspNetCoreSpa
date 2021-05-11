using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.CreateAutomobile
{
    public class CreateAutomobileCommand : IRequest
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

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
                var entity = new Automobile
                {
                    AutomobileId = request.Id,
                    ClientId = request.ClientId,
                    CarExpertId = request.CarExpertId,
                    Brand = request.Brand,
                    Color = request.Color,
                    Model = request.Model,
                    PlateNumber = request.PlateNumber,
                    Year = request.Year,
                };

                _context.Automobiles.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new AutomobileCreated { AutomobileId = entity.AutomobileId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
