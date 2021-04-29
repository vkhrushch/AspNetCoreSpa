using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.CarExperts.Commands.CreateCarExpert
{
    public class CreateCarExpertCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public class Handler : IRequestHandler<CreateCarExpertCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateCarExpertCommand request, CancellationToken cancellationToken)
            {
                var entity = new CarExpert
                {
                    CarExpertId = request.Id,
                    Name = request.Name,
                    Level = request.Level
                };

                _context.CarExperts.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new CarExpertCreated { CarExpertId = entity.CarExpertId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}
