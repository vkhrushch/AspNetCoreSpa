using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using System;

namespace AspNetCoreSpa.Application.Features.Participants.Queries.GetParticipantList
{
    public class ParticipantLookupDto : IMapFrom<Participant>
    {
        public int ChatRoomId { get; set; }
        public Guid UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Participant, ParticipantLookupDto>()
                .ForMember(d => d.ChatRoomId, opt => opt.MapFrom(s => s.ChatRoomId))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId));
        }
    }
}
