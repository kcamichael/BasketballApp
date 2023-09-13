﻿// <auto-generated />
using BasketballApp.Data.BasketballDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasketballApp.Data.Migrations
{
    [DbContext(typeof(BasketballDbContext))]
    partial class BasketballDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasketballApp.Data.Entities.CoachEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("CollegeId");

                    b.ToTable("Coach");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CollegeId = 1,
                            Name = "Mike Woodson"
                        },
                        new
                        {
                            ID = 2,
                            CollegeId = 2,
                            Name = "Matt Painter"
                        });
                });

            modelBuilder.Entity("BasketballApp.Data.Entities.CollegeEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Arena")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Conference")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("College");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Arena = "Assembly Hall",
                            City = "Bloomington",
                            Conference = "Big Ten",
                            Name = "Indiana University",
                            State = "Indiana"
                        },
                        new
                        {
                            ID = 2,
                            Arena = "Mackey Arena",
                            City = "West Lafayette",
                            Conference = "Big Ten",
                            Name = "Purdue University",
                            State = "Indiana"
                        });
                });

            modelBuilder.Entity("BasketballApp.Data.Entities.PlayerEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("HighSchool")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CollegeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CollegeId = 2,
                            Height = 88,
                            HighSchool = "IMG Academy",
                            Name = "Zach Edey",
                            Number = 15,
                            PositionId = 5,
                            Weight = 305
                        },
                        new
                        {
                            ID = 2,
                            CollegeId = 1,
                            Height = 80,
                            HighSchool = "Roselle Catholic High School",
                            Name = "Mackenzie Mgbako",
                            Number = 21,
                            PositionId = 3,
                            Weight = 215
                        });
                });

            modelBuilder.Entity("BasketballApp.Data.Entities.PositionEntity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Position");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Point Guard"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Shooting Guard"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Small Forward"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Power Forward"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Center"
                        });
                });

            modelBuilder.Entity("BasketballApp.Data.Entities.CoachEntity", b =>
                {
                    b.HasOne("BasketballApp.Data.Entities.CollegeEntity", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");
                });

            modelBuilder.Entity("BasketballApp.Data.Entities.PlayerEntity", b =>
                {
                    b.HasOne("BasketballApp.Data.Entities.CollegeEntity", "College")
                        .WithMany()
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BasketballApp.Data.Entities.PositionEntity", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
