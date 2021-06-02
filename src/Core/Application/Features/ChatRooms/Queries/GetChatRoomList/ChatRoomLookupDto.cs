using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;


namespace AspNetCoreSpa.Application.Features.ChatRooms.Queries.GetChatRoomList
{
    public class ChatRoomLookupDto : IMapFrom<ChatRoom>
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChatRoom, ChatRoomLookupDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.RoomId, opt => opt.MapFrom(s => s.ChatRoomId));
        }
    }
}
