using AspNetCoreSpa.Domain.Entities;
using AutoMapper;

namespace AspNetCoreSpa.Application.Features.Games.Queries.GetGameDetail
{
    public class GameDetailVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameDetailVm>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.GameId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Difficulty, opt => opt.MapFrom(s => s.DifficultyLevel.Name));
        }
    }
}
