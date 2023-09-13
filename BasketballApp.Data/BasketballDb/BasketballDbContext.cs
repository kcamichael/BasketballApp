using BasketballApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketballApp.Data.BasketballDb
{
    public class BasketballDbContext : DbContext
    {
        public BasketballDbContext(DbContextOptions options) : base(options) { }

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<CoachEntity> Coach { get; set; }
        public DbSet<CollegeEntity> College { get; set; }
        public DbSet<PositionEntity> Position { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); builder.Entity<PlayerEntity>().HasData(
                new PlayerEntity
                {
                    ID = 1,
                    Name = "Zach Edey",
                    Number = 15,
                    CollegeId = 2, 
                    PositionId = 5, 
                    HighSchool = "IMG Academy",
                    Height = 88,
                    Weight = 305
                },
                new PlayerEntity
                {
                    ID = 2,
                    Name = "Mackenzie Mgbako",
                    Number = 21,
                    CollegeId = 1,
                    PositionId = 3,
                    HighSchool = "Roselle Catholic High School",
                    Height = 80,
                    Weight = 215
                }
            );
            builder.Entity<PositionEntity>().HasData(
                new PositionEntity { ID = 1, Name = "Point Guard" },
                new PositionEntity { ID = 2, Name = "Shooting Guard" },
                new PositionEntity { ID = 3, Name = "Small Forward" },
                new PositionEntity { ID = 4, Name = "Power Forward" },
                new PositionEntity { ID = 5, Name = "Center" }
            );
            builder.Entity<CoachEntity>().HasData(
                new CoachEntity
                {
                    ID = 1,
                    Name = "Mike Woodson",
                    CollegeId = 1
                },
                new CoachEntity
                {
                    ID = 2,
                    Name = "Matt Painter",
                    CollegeId = 2,
                }
            );
            builder.Entity<CollegeEntity>().HasData(
                new CollegeEntity
                {
                    ID = 1,
                    Name = "Indiana University",
                    Conference = "Big Ten",
                    City = "Bloomington",
                    State = "Indiana",
                    Arena = "Assembly Hall"
                },
                new CollegeEntity
                {
                    ID = 2,
                    Name = "Purdue University",
                    Conference = "Big Ten",
                    City = "West Lafayette",
                    State = "Indiana",
                    Arena = "Mackey Arena"
                }
            );

        }
    }
}
