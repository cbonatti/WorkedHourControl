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

        public Project(string name, ICollection<ProjectTeam> teams) : this(name)
        {
            Teams = teams;
        }

        public string Name { get; private set; }
        public virtual ICollection<ProjectTeam> Teams { get; private set; }
        public virtual ICollection<ProjectWorkedHour> WorkedHours { get; private set; }

        public Project ChangeName(string name)
        {
            Name = name;
            return this;
        }

        public Project AddTeam(long teamId)
        {
            if (!Teams.Any(x => x.TeamId == teamId))
                Teams.Add(new ProjectTeam(teamId));

            return this;
        }

        public Project RemoveTeam(ProjectTeam projectTeam)
        {
            Teams.Remove(projectTeam);
            return this;
        }

        public Project AddWorkHour(long employeeId, long teamId, DateTime date, decimal time)
        {
            if (WorkedHours == null)
                WorkedHours = new List<ProjectWorkedHour>();

            var workedHour = WorkedHours.Where(x => x.EmployeeId == employeeId && x.Date.Date == date.Date).FirstOrDefault();
            if (workedHour == null)
                WorkedHours.Add(new ProjectWorkedHour(Id, employeeId, teamId, date, time));
            else
                workedHour.ChangeWorkedHour(time, teamId);

            return this;
        }
    }
}
