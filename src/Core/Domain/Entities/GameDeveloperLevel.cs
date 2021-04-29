using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities
{
    public class GameDeveloperLevel
    {
        public int GameDeveloperLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<GameDeveloper> DevelopersOfLevel { get; private set; }

        public GameDeveloperLevel()
        {
            DevelopersOfLevel = new HashSet<GameDeveloper>();
        }
    }
}
