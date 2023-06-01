using DBApiTutorial.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DBApiTutorial.Infrastructure
{
    public class CompanyDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<OfficeEmployee> OfficeEmployees { get; set; }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder mb)
        {
        }
    }
}
