using Microsoft.EntityFrameworkCore;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping;

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

            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new TeamEmployeeMap());
            modelBuilder.ApplyConfiguration(new TeamMap());
            modelBuilder.ApplyConfiguration(new ProjectTeamMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ProjectWorkedHourMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
