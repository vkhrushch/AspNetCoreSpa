using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.Automobiles.Commands.UpdateAutomobile
{
    public class UpdateAutomobileCommand : IRequest
    {
        public AutomobileLookupDto Auto { get; set; }

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
                    .SingleOrDefaultAsync(c => c.AutomobileId == request.Auto.AutomobileId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Automobile), request.Auto.AutomobileId);
                }

                entity.ClientId = request.Auto.ClientId;
                entity.CarExpertId = request.Auto.CarExpertId;
                entity.Brand = request.Auto.Brand;
                entity.Color = request.Auto.Color;
                entity.Model = request.Auto.Model;
                entity.PlateNumber = request.Auto.PlateNumber;
                entity.Year = request.Auto.Year;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
