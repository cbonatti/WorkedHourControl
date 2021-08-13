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

            modelBuilder.Entity<Employee>().HasKey(x => x.Id);
            modelBuilder.Entity<Employee>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<TeamEmployee>()
                .HasOne(bc => bc.Employee)
                .WithMany(b => b.Teams)
                .HasForeignKey(bc => bc.EmployeeId);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Username).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.EmployeeId).IsRequired();
            modelBuilder.Entity<User>().HasOne(x => x.Employee);

            modelBuilder.Entity<Team>().HasMany(x => x.Employees);
            modelBuilder.Entity<Team>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Team>().HasKey(x => x.Id);
            modelBuilder.Entity<TeamEmployee>()
                .HasOne(bc => bc.Team)
                .WithMany(b => b.Employees)
                .HasForeignKey(bc => bc.TeamId);
            modelBuilder.Entity<ProjectTeam>()
                .HasOne(bc => bc.Team)
                .WithMany(b => b.Projects)
                .HasForeignKey(bc => bc.TeamId);

            modelBuilder.Entity<Project>().HasMany(x => x.Teams);
            modelBuilder.Entity<Project>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Project>().HasKey(x => x.Id);
            modelBuilder.Entity<ProjectTeam>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.Teams)
                .HasForeignKey(bc => bc.ProjectId);

            modelBuilder.Entity<ProjectWorkedHour>().HasKey(x => x.Id);
            modelBuilder.Entity<ProjectWorkedHour>().Property(x => x.Date).IsRequired();
            modelBuilder.Entity<ProjectWorkedHour>().Property(x => x.TimeSpent).IsRequired();
            modelBuilder.Entity<ProjectWorkedHour>()
                .HasOne(bc => bc.Project)
                .WithMany(b => b.WorkedHours)
                .HasForeignKey(bc => bc.ProjectId);
        }
    }
}
