using System.Collections.Generic;
using AspNetCoreSpa.Domain.Entities.ManyToMany;

namespace AspNetCoreSpa.Domain.Entities
{
    public class GameGenre : AuditableEntity
    {
        public int GameGenreId { get; set; }
        public string Name { get; set; }

        public ICollection<GameGenreGame> GamesOfGenre { get; set; }

        public GameGenre()
        {
            GamesOfGenre = new HashSet<GameGenreGame>();
        }
    }
}
