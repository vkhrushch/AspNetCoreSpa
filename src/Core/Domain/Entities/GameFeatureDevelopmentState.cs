using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities
{
    public class GameFeatureDevelopmentState
    {
        public int GameFeatureDevelopmentStateId { get; set; }
        public string Name { get; set; }

        public ICollection<GameFeature> FeaturesInState { get; private set; }

        public GameFeatureDevelopmentState()
        {
            FeaturesInState = new HashSet<GameFeature>();
        }
    }
}
