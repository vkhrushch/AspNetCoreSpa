using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientList
{
    public class ClientLookupDto : IMapFrom<Client>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientLookupDto>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName));
        }
    }
}
