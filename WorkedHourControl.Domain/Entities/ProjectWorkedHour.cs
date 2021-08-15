using System;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class ProjectWorkedHour : EntityBase
    {
        public ProjectWorkedHour(long projectId, long employeeId, long teamId, DateTime date, decimal timeSpent)
        {
            ProjectId = projectId;
            EmployeeId = employeeId;
            TeamId = teamId;
            Date = date;
            TimeSpent = timeSpent;
        }

        public long ProjectId { get; private set; }
        public virtual Project Project { get; private set; }
        public long TeamId { get; private set; }
        public virtual Team Team { get; private set; }
        public long EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }
        public DateTime Date { get; set; }
        public decimal TimeSpent { get; set; }
    }
}
