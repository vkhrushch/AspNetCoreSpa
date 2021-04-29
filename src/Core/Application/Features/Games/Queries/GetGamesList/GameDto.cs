using AspNetCoreSpa.Application.Common.Mappings;
using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGamesList
{
    public class GameDto : IMapFrom<Game>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.GameId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Difficulty, opt => opt.MapFrom(s => s.DifficultyLevel.Name));
        }
    }
}
