using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameAPI.Data.Entities;

namespace VideoGameAPI.Data
{
    public class LibraryDbContext : IdentityDbContext
    {
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<VideoGameEntity> Videogames { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CompanyEntity>().ToTable("Companies");
            modelBuilder.Entity<CompanyEntity>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CompanyEntity>().HasMany(c => c.Videogames).WithOne(v => v.Company);

            modelBuilder.Entity<VideoGameEntity>().ToTable("Videogames");
            modelBuilder.Entity<VideoGameEntity>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<VideoGameEntity>().HasOne(v => v.Company).WithMany(c => c.Videogames);
        }


        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add InitialCreate
        //dotnet ef database update

    }
}
