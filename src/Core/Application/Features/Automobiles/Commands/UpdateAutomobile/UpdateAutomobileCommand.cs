using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.UpdateAutomobile
{
    public class UpdateAutomobileCommand : IRequest
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public class Handler : IRequestHandler<UpdateAutomobileCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateAutomobileCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Automobiles
                    .SingleOrDefaultAsync(c => c.AutomobileId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Automobile), request.Id);
                }

                entity.ClientId = request.ClientId;
                entity.CarExpertId = request.CarExpertId;
                entity.Brand = request.Brand;
                entity.Color = request.Color;
                entity.Model = request.Model;
                entity.PlateNumber = request.PlateNumber;
                entity.Year = request.Year;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
