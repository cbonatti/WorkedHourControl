using System;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class ProjectWorkedHour : EntityBase
    {
        public ProjectWorkedHour(long projectId, long employeeId, DateTime date, decimal timeSpent)
        {
            ProjectId = projectId;
            EmployeeId = employeeId;
            Date = date;
            TimeSpent = timeSpent;
        }

        public long ProjectId { get; private set; }
        public virtual Project Project { get; private set; }
        public long EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }
        public DateTime Date { get; set; }
        public decimal TimeSpent { get; set; }
    }
}
