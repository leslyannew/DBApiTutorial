﻿// <auto-generated />
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBApiTutorial.Migrations
{
    [DbContext(typeof(OrgDBContext))]
    partial class CompanyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Robert",
                            LastName = "Smith"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Pamela",
                            LastName = "Johnson"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "John",
                            LastName = "Franklin"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Kathy",
                            LastName = "McDonald"
                        });
                });

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId")
                        .IsUnique();

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Baton Rouge",
                            Phone = "555-222-2222",
                            RegionId = 1,
                            State = "LA"
                        },
                        new
                        {
                            Id = 2,
                            City = "Port Allen",
                            Phone = "555-123-4567",
                            RegionId = 2,
                            State = "LA"
                        },
                        new
                        {
                            Id = 3,
                            City = "Gonzales",
                            Phone = "555-777-7777",
                            RegionId = 3,
                            State = "LA"
                        },
                        new
                        {
                            Id = 4,
                            City = "Plaquemine",
                            Phone = "555-444-4444",
                            RegionId = 4,
                            State = "LA"
                        });
                });

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.OfficeEmployee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("OfficeEmployees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 1,
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 2,
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 3,
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 3,
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 4,
                            OfficeId = 4
                        });
                });

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "East Baton Rouge"
                        },
                        new
                        {
                            Id = 2,
                            Name = "West Baton Rouge"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Ascension"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Iberville"
                        });
                });

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.Office", b =>
                {
                    b.HasOne("DBApiTutorial.Domain.Entity.Region", null)
                        .WithOne()
                        .HasForeignKey("DBApiTutorial.Domain.Entity.Office", "RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.OfficeEmployee", b =>
                {
                    b.HasOne("DBApiTutorial.Domain.Entity.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBApiTutorial.Domain.Entity.Office", null)
                        .WithMany()
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
