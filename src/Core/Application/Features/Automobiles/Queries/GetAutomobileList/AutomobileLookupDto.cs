using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Automobiles.Queries.GetAutomobileList
{
    public class AutomobileLookupDto : IMapFrom<Automobile>
    {
        public string AutomobileId { get; set; }
        public string ClientId { get; set; }
        public string CarExpertId { get; set; }
        public string PlateNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Automobile, AutomobileLookupDto>()
                .ForMember(d => d.AutomobileId, opt => opt.MapFrom(s => s.AutomobileId))
                .ForMember(d => d.ClientId, opt => opt.MapFrom(s => s.ClientId))
                .ForMember(d => d.CarExpertId, opt => opt.MapFrom(s => s.CarExpertId))
                .ForMember(d => d.PlateNumber, opt => opt.MapFrom(s => s.PlateNumber))
                .ForMember(d => d.Color, opt => opt.MapFrom(s => s.Color))
                .ForMember(d => d.Brand, opt => opt.MapFrom(s => s.Brand))
                .ForMember(d => d.Model, opt => opt.MapFrom(s => s.Model))
                .ForMember(d => d.Year, opt => opt.MapFrom(s => s.Year));
        }
    }
}
