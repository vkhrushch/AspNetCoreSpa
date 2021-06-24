using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using System;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageList
{
    public class MessageLookupDto : IMapFrom<Message>
    {
        public int MessageId { get; set; }
        public int ChatRoomId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string MessageTime { get; set; }
        public Guid UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageLookupDto>()
                .ForMember(d => d.MessageId, opt => opt.MapFrom(s => s.MessageId))
                .ForMember(d => d.ChatRoomId, opt => opt.MapFrom(s => s.ChatRoomId))
                .ForMember(d => d.MessageTime, opt => opt.MapFrom(s => s.MessageTime))
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.UserName))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.UserId))
                .ForMember(d => d.Text, opt => opt.MapFrom(s => s.Text));
        }
    }
}
