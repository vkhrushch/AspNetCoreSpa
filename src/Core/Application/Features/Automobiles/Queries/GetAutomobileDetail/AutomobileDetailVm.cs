using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail
{
    public class AutomobileDetailVm : IMapFrom<Automobile>
    {
        public string Id { get; set; }
        public string ClientId { get; set; }
        public string CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Automobile, AutomobileDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AutomobileId));
        }
    }
}
