using System.Collections.Generic;

namespace AspNetCoreSpa.Domain.Entities.ManyToMany
{
    public class GameGenreGame
    {
        public int GameGenreId { get; set; }
        public GameGenre GameGenre { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
