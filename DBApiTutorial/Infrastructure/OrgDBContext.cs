using DBApiTutorial.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DBApiTutorial.Infrastructure
{
    public class OrgDBContext : DbContext
    {
        
        public DbSet<Region> Regions { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeEmployee> OfficeEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public OrgDBContext(DbContextOptions<OrgDBContext> options) : base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Office>()
                .HasOne<Region>()
                .WithOne();

            mb.Entity<Office>()
                .HasMany<Employee>()
                .WithMany()
                .UsingEntity<OfficeEmployee>();

            mb.Entity<Region>().HasData(
                new Region()
                {
                    Id = 1,
                    Name = "East Baton Rouge"
                },
                new Region()
                {
                    Id = 2,
                    Name = "West Baton Rouge"
                },
                new Region()
                {
                    Id = 3,
                    Name = "Ascension"
                },
                new Region()
                {
                    Id = 4,
                    Name = "Iberville"
                });
            mb.Entity<Office>().HasData(
                new Office()
                {
                    Id = 1,
                    RegionId = 1,
                    City = "Baton Rouge",
                    Phone = "555-222-2222"
                },
                new Office()
                {
                    Id = 2,
                    RegionId = 2,
                    City = "Port Allen",
                    Phone = "555-123-4567"
                },
                new Office()
                {
                    Id = 3,
                    RegionId = 3,
                    City = "Gonzales",
                    Phone = "555-777-7777"
                },
                new Office()
                {
                    Id = 4,
                    RegionId = 4,
                    City = "Plaquemine",
                    Phone = "555-444-4444"
                });
            mb.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    FirstName = "Robert",
                    LastName = "Smith",
                },
                new Employee()
                {
                    Id = 2,
                    FirstName = "Pamela",
                    LastName = "Johnson",
                },
                new Employee()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Franklin",
                },
                new Employee()
                {
                    Id = 4,
                    FirstName = "Kathy",
                    LastName = "McDonald"
                });
            mb.Entity<OfficeEmployee>().HasData(
                new OfficeEmployee()
                {
                    Id = 1,
                    EmployeeId = 1,
                    OfficeId = 1
                },
                new OfficeEmployee()
                {
                    Id = 2,
                    EmployeeId = 1,
                    OfficeId = 2
                },
                new OfficeEmployee()
                {
                    Id = 3,
                    EmployeeId = 2,
                    OfficeId = 2
                },
                new OfficeEmployee()
                {
                    Id = 4,
                    EmployeeId = 3,
                    OfficeId = 3
                },
                new OfficeEmployee()
                {
                    Id = 5,
                    EmployeeId = 3,
                    OfficeId = 4
                },
                new OfficeEmployee()
                {
                    Id = 6,
                    EmployeeId = 4,
                    OfficeId = 4
                });

        }
    }
}
