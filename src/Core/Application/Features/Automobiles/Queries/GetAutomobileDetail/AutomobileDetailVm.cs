using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileDetail
{
    public class AutomobileDetailVm : IMapFrom<Automobile>
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int CarExpertId { get; set; }
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
