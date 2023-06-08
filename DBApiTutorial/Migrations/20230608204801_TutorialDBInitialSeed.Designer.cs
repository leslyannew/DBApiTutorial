﻿// <auto-generated />
using DBApiTutorial.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DBApiTutorial.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    [Migration("20230608204801_TutorialDBInitialSeed")]
    partial class TutorialDBInitialSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DBApiTutorial.Domain.Entity.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId")
                        .IsUnique();

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Building = "A",
                            RegionId = 1,
                            State = "WI"
                        },
                        new
                        {
                            Id = 2,
                            Building = "B",
                            City = "Baton Rouge",
                            Phone = "555-765-4321",
                            RegionId = 2,
                            State = "LA"
                        },
                        new
                        {
                            Id = 3,
                            Building = "C",
                            Phone = "555-555-5555",
                            RegionId = 4
                        },
                        new
                        {
                            Id = 4,
                            Building = "D",
                            Phone = "555-111-1111",
                            RegionId = 3,
                            State = "CA"
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
                            Name = "North"
                        },
                        new
                        {
                            Id = 2,
                            Name = "South"
                        },
                        new
                        {
                            Id = 3,
                            Name = "East"
                        },
                        new
                        {
                            Id = 4,
                            Name = "West"
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
#pragma warning restore 612, 618
        }
    }
}
