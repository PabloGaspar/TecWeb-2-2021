using FootballAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballAPI.Data
{
    public class FootballDbContext: DbContext
    {
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }

        public FootballDbContext(DbContextOptions<FootballDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamEntity>().ToTable("Teams");
            modelBuilder.Entity<TeamEntity>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<TeamEntity>().HasMany(t => t.Players).WithOne(p => p.Team);

            modelBuilder.Entity<PlayerEntity>().ToTable("Players");
            modelBuilder.Entity<PlayerEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PlayerEntity>().HasOne(p => p.Team).WithMany(t => t.Players);

            //dotnet tool install --global dotnet-ef
            //dotnet ef migrations add InitialCreate
            //dotnet ef database update
        }
    }
}
