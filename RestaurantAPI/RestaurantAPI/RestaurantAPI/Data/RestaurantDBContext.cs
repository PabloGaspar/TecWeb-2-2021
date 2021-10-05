using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Data
{
    public class RestaurantDBContext : DbContext
    {
        public DbSet<RestaurantEntity> Restaurants { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }

        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RestaurantEntity>().ToTable("Restaurants");
            modelBuilder.Entity<RestaurantEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<RestaurantEntity>().HasMany(r => r.Dishes).WithOne(d => d.Restaurant);

            modelBuilder.Entity<DishEntity>().ToTable("Dishes");
            modelBuilder.Entity<DishEntity>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<DishEntity>().HasOne(d => d.Restaurant).WithMany(r => r.Dishes);

            //https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
            //dotnet tool install --global dotnet-ef
            //dotnet ef --help
            //dotnet ef migrations add {InitialCreate}
            //dotnet ef database update

        }
    }
}
