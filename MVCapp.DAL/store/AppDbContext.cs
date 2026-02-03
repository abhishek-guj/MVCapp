using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MVCapp.DAL.Entities;

namespace MVCapp.DAL.Store
{
    public class AppDbContext : DbContext
    {
        // --- users ---
        public DbSet<Product> Products => Set<Product>();


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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