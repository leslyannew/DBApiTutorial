﻿using DBApiTutorial.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace DBApiTutorial.Infrastructure
{
    public class CompanyDBContext : DbContext
    {
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Region> Regions { get; set; }
        //public DbSet<OfficeEmployee> OfficeEmployees { get; set; }

        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Region>().HasData(
                new Region()
                {
                    Id = 1,
                    Name = "North"
                },
                new Region()
                {
                    Id = 2,
                    Name = "South"
                },
                new Region()
                {
                    Id = 3,
                    Name = "East"
                },
                new Region()
                {
                    Id = 4,
                    Name = "West"
                });
            mb.Entity<Office>().HasData(
                new Office()
                {
                    Id = 1,
                    Building = "A",
                    RegionId = 1
                },
                new Office()
                {
                    Id = 2,
                    Building = "B",
                    RegionId = 2
                },
                new Office()
                {
                    Id = 3,
                    Building = "C",
                    RegionId = 4
                },
                new Office()
                {
                    Id = 4,
                    Building = "D",
                    RegionId = 3
                });
        }
    }
}
