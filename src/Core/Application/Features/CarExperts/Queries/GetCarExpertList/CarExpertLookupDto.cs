using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertList
{
    public class CarExpertLookupDto : IMapFrom<CarExpert>
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CarExpert, CarExpertLookupDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Level, opt => opt.MapFrom(s => s.Level));
        }
    }
}
