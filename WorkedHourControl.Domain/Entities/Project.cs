using System;
using System.Collections.Generic;
using System.Linq;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class Project : EntityBase
    {
        public Project()
        {
        }

        public Project(string name)
        {
            Name = name;
        }

        public Project(string name, ICollection<Team> teams) : this(name)
        {
            Teams = teams;
        }

        public string Name { get; private set; }
        public virtual ICollection<Team> Teams { get; private set; }
        public virtual ICollection<ProjectWorkedHour> WorkedHours { get; private set; }

        public Project ChangeName(string name)
        {
            Name = name;
            return this;
        }

        public Project AddEmployee(Team team)
        {
            if (Teams == null)
                Teams = new List<Team>();

            if (!Teams.Any(x => x.Id == team.Id))
                Teams.Add(team);

            return this;
        }

        public Project RemoveEmployee(Team team)
        {
            Teams.Remove(team);
            return this;
        }

        public Project AddWorkHour(long employeeId, DateTime date, decimal time)
        {
            if (WorkedHours == null)
                WorkedHours = new List<ProjectWorkedHour>();

            var workedHour = WorkedHours.Where(x => x.EmployeeId == employeeId && x.Date == date).FirstOrDefault();
            if (workedHour == null)
            {
                workedHour = new ProjectWorkedHour(Id, employeeId, date, time);
                WorkedHours.Add(workedHour);
            }
            else
            {
                workedHour.TimeSpent = time;
            }

            return this;
        }
    }
}
