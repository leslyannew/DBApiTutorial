using DBApiTutorial.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Infrastructure
{
    public class GamePubDbContext : DbContext
    {
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }   
        public DbSet<Soundtrack> Soundtracks { get; set; }

        public GamePubDbContext(DbContextOptions<GamePubDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Studio>().HasData(
                new Studio("NotNintendo")
                {
                    Id = 1
                },
                new Studio("Supersmall Games")
                {
                    Id = 2
                },
                new Studio("OuterSloth Games")
                {
                    Id = 3
                });
            mb.Entity<Game>().HasData(
                new Game("Legend of Zilda")
                {
                    Id = 1,
                    StudioId = 1
                },
                new Game("Super Maria")
                {
                    Id = 2,
                    StudioId = 1
                },
                new Game("Semiconductor")
                {
                    Id = 2,
                    StudioId = 1
                },
                new Game("Hercules")
                {
                    Id = 3,
                    StudioId = 1
                },
                new Game("Amidst Us")
                {
                    Id = 3,
                    StudioId = 1
                });
        }
    }
}
