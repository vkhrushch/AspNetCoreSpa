using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Application.Exceptions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.CarExperts.Commands.UpdateCarExpert
{
    public class UpdateCarExpertCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public class Handler : IRequestHandler<UpdateCarExpertCommand>
        {
            private readonly IApplicationDbContext _context;

            public Handler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCarExpertCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.CarExperts
                    .SingleOrDefaultAsync(c => c.CarExpertId == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(CarExpert), request.Id);
                }

                entity.Name = request.Name;
                entity.Level = request.Level;


                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
