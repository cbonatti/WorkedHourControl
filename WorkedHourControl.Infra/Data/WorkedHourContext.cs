using Microsoft.EntityFrameworkCore;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Infra.Data
{
    public class WorkedHourContext : DbContext
    {
        public WorkedHourContext(DbContextOptions<WorkedHourContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
