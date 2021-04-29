using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities
{
    public class GameDifficultyLevel
    {
        public int GameDifficultyLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<Game> GamesOfDifficultyLevel { get; private set; }

        public GameDifficultyLevel()
        {
            GamesOfDifficultyLevel = new HashSet<Game>();
        }
    }
}
