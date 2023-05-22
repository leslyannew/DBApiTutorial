using DBApiTutorial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Infrastructure
{
    public class OrgDbContext : DbContext
    {
        //DbSet(s) go here

        public OrgDbContext(DbContextOptions<OrgDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            
                
        }
    }
}
