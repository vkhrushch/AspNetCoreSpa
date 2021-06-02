using System.Threading;
using System.Threading.Tasks;
using AspNetCoreSpa.Application.Abstractions;
using AspNetCoreSpa.Common;
using AspNetCoreSpa.Domain.Entities;
using AspNetCoreSpa.Domain.Entities.ManyToMany;
using AspNetCoreSpa.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreSpa.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<ChatRoom> ChatRooms { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<CarExpert> CarExperts { get; set; }

        public DbSet<Automobile> Automobiles { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<Shipper> Shippers { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Territory> Territories { get; set; }

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

        public DbSet<ContactUs> ContactUs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId.ToString();
                        entry.Entity.Created = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId.ToString();
                        entry.Entity.LastModified = _dateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}

