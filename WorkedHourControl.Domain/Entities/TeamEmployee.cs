using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class TeamEmployee : EntityBase
    {
        public TeamEmployee()
        {
        }

        public TeamEmployee(long employeeId)
        {
            EmployeeId = employeeId;
        }

        public long TeamId { get; private set; }
        public virtual Team Team { get; private set; }
        public long EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }
    }
}
