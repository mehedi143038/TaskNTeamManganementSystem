using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskNTeamManganementSystem.Domain.Entities;
using Task = TaskNTeamManganementSystem.Domain.Entities.Task;

namespace TaskNTeamManganementSystem.Infrastructure.Persistent.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add any additional configuration here if needed
            modelBuilder.Entity<User>().ToTable("tbl_Users");
            modelBuilder.Entity<Team>().ToTable("tbl_Teams");
            modelBuilder.Entity<Task>().ToTable("tbl_Tasks");
        }
    }
}
