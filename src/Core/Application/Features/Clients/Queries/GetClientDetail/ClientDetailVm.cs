using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;


namespace AspNetCoreSpa.Application.Features.Clients.Queries.GetClientDetail
{
    public class ClientDetailVm : IMapFrom<Client>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, ClientDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ClientId));
        }
    }
}
