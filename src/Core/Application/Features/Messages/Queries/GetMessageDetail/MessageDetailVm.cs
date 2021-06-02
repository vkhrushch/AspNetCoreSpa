using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;
using System;

namespace AspNetCoreSpa.Application.Features.Messages.Queries.GetMessageDetail
{
    public class MessageDetailVm : IMapFrom<Message>
    {
        public int Id { get; set; }
        public int ChatRoomId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime MessageTime { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Message, MessageDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.MessageId));
        }
    }
}
