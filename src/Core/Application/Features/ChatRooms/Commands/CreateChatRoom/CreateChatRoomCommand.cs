﻿using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Commands.CreateChatRoom
{
    public class CreateChatRoomCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<Guid, string> Participents { get; set; }

        public class Handler : IRequestHandler<CreateChatRoomCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMediator _mediator;

            public Handler(IApplicationDbContext context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }

            public async Task<Unit> Handle(CreateChatRoomCommand request, CancellationToken cancellationToken)
            {
                var entity = new ChatRoom
                {
                    ChatRoomId = request.Id,
                    Name = request.Name,
                };

                _context.ChatRooms.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                foreach (var participant in request.Participents)
                {
                    Participant participant1 = new Participant
                    {
                        ChatRoomId = entity.ChatRoomId,
                        UserId = participant.Key
                    };
                    _context.Participants.Add(participant1);
                }
                await _context.SaveChangesAsync(cancellationToken);
                await _mediator.Publish(new ChatRoomCreated { ChatRoomId = entity.ChatRoomId }, cancellationToken);

                return Unit.Value;
            }
        }
    }
}