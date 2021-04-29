namespace AspNetCoreSpa.Domain.Entities
{
    public class GameFeature
    {
        public int GameFeatureId { get; set; }
        public Game Game { get; set; }
        public GameDeveloper Developer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GameFeatureDevelopmentState DevelopmentState { get; set; }

        public int GameId { get; set; }
        public int DeveloperId { get; set; }
        public int DevelopmentStateId { get; set; }
    }
}
