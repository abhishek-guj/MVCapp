using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCapp.DAL.Entities;

namespace MVCapp.DAL.Store
{
    public class AppDbContext : DbContext
    {
        // --- users ---
        public DbSet<User> Users => Set<User>();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public static DbContextOptions<AppDbContext> GetOptions(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new ArgumentNullException("Connection string 'DefaultConnection' not found.");

            return new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
            });


        }
    }
}