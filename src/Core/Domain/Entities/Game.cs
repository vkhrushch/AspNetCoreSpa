using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.ManyToMany;

namespace AspNetCoreSpa.Domain.Entities
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public GameDifficultyLevel DifficultyLevel { get; set; }

        public int GameDifficultyLevelId { get; set; }

        public ICollection<GameGenreGame> Genres { get; private set; }
        public ICollection<GameFeature> FeaturesInDevelopment { get; private set; }

        public Game()
        {
            Genres = new HashSet<GameGenreGame>();
            FeaturesInDevelopment = new HashSet<GameFeature>();
        }
    }
}
