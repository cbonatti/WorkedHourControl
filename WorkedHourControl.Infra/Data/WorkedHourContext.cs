using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Infra.Data.Mapping;

namespace WorkedHourControl.Infra.Data
{
    public class WorkedHourContext : DbContext
    {
        public WorkedHourContext(DbContextOptions<WorkedHourContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectWorkedHour> WorkedHour { get; set; }
        
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

            var employee = new Employee(1, "Gestor", Profile.Manager);

            modelBuilder.Entity<Employee>().HasData(new List<Employee>()
            {
                employee
            });

            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User(1, "gestor", "123Mudar", employee)
            });

            
        }
    }
}
