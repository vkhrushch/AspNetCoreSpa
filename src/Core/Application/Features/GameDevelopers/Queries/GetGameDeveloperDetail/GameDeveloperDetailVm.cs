using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.GameDevelopers.Queries.GetGameDeveloperDetail
{
    public class GameDeveloperDetailVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string DeveloperLevel { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GameDeveloper, GameDeveloperDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.GameDeveloperId))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.Age, opt => opt.MapFrom(s => s.Age))
                .ForMember(d => d.DeveloperLevel, opt => opt.MapFrom(s => s.DeveloperLevel.Name));
        }
    }
}
