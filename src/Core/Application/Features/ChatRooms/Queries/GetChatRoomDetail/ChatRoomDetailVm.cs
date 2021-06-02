﻿using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomDetail
{
    public class ChatRoomDetailVm : IMapFrom<ChatRoom>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChatRoom, ChatRoomDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ChatRoomId));
        }
    }
}
