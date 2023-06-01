/*
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.GamePublisher
{
    public class GamePubDbContext : DbContext
    {
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<Developer> Developers { get; set; }   
        //public DbSet<Soundtrack> Soundtracks { get; set; }

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
                new Game("Legend of Zilda: Fears of the Kingdom")
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
                    Id = 3,
                    StudioId = 2
                },
                new Game("Hercules")
                {
                    Id = 4,
                    StudioId = 2
                },
                new Game("Amidst Us")
                {
                    Id = 5,
                    StudioId = 3
                });
            
            mb.Entity<Developer>().HasData(
                new Developer("Eiyu", "Izumi")
                {
                    Id = 1,
                    StudioId = 1
                },
                new Developer("Chiaki", "Hirota")
                {
                    Id = 2,
                    StudioId = 1
                },
                new Developer("Miki", "Takemoto")
                {
                    Id = 3,
                    StudioId = 1
                },
                new Developer("Gerry", "Griffin")
                {
                    Id = 4,
                    StudioId = 2
                },
                new Developer("Roland", "Olsen")
                {
                    Id = 5,
                    StudioId = 2
                },
                new Developer("Erika", "Barrett")
                {
                    Id = 6,
                    StudioId = 3
                },
                new Developer("Oscar", "Price")
                {
                    Id = 7,
                    StudioId = 3
                });
            mb.Entity<Soundtrack>().HasData(
                new Soundtrack()
                {
                    Id = 1,
                    GameId = 1
                },
                new Soundtrack()
                {
                    Id = 2,
                    GameId = 2
                },
                new Soundtrack()
                {
                    Id = 3,
                    GameId = 3
                },
                new Soundtrack()
                {
                    Id = 4,
                    GameId = 4
                },
                new Soundtrack()
                {
                    Id = 5,
                    GameId = 5
                });
            
        }
    }
}
*/