using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AspNetCoreSpa.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Customer> Customers { get; set; }

        DbSet<Client> Clients { get; set; }

        DbSet<CarExpert> CarExperts { get; set; }

        DbSet<Automobile> Automobiles { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        DbSet<OrderDetail> OrderDetails { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<Region> Region { get; set; }

        DbSet<Shipper> Shippers { get; set; }

        DbSet<Supplier> Suppliers { get; set; }

        DbSet<Territory> Territories { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameDeveloper> GameDevelopers { get; set; }

        public DbSet<GameDeveloperLevel> GameDeveloperLevels { get; set; }

        public DbSet<GameDifficultyLevel> GameDifficultyLevels { get; set; }

        public DbSet<GameFeature> GameFeatures { get; set; }

        public DbSet<GameFeatureDevelopmentState> GameFeatureDevelopmentStates { get; set; }

        public DbSet<GameGenre> GameGenres { get; set; }

        /// <summary>
        /// Many-to-many
        /// </summary>
        public DbSet<GameGenreGame> GameGenreGames { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
