using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities
{
    public class GameDeveloper
    {
        public int GameDeveloperId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GameDeveloperLevel DeveloperLevel { get; set; }

        public int DeveloperLevelId { get; set; }

        public ICollection<GameFeature> GameFeaturesAssigned { get; private set; }

        public GameDeveloper()
        {
            GameFeaturesAssigned = new HashSet<GameFeature>();
        }
    }
}
