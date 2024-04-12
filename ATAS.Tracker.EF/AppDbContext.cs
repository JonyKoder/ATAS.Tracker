
using ATAS.Tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace ATAS.Tracker.EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
