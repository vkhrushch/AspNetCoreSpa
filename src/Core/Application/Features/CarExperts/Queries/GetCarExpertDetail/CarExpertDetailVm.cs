using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.CarExperts.Queries.GetCarExpertDetail
{
    public class CarExpertDetailVm : IMapFrom<CarExpert>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CarExpert, CarExpertDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CarExpertId));
        }
    }
}
