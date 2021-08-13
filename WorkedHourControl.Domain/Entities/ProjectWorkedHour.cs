using System;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class ProjectWorkedHour : EntityBase
    {
        public ProjectWorkedHour(long projectId, long employeeId, DateTime date, decimal spentTime)
        {
            ProjectId = projectId;
            EmployeeId = employeeId;
            Date = date;
            SpentTime = spentTime;
        }

        public long ProjectId { get; private set; }
        public virtual Project Project { get; private set; }
        public long EmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public DateTime Date { get; set; }
        public decimal SpentTime { get; set; }
    }
}
