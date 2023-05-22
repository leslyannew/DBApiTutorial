using DBApiTutorial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Infrastructure
{
    public class StoreDbContext : DbContext
    {
        //DbSet(s) go here

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            
        }
    }
}
