using System.Collections.Generic;
using System.Linq;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class Team : EntityBase
    {
        public Team()
        {
        }

        public Team(string name)
        {
            Name = name;
        }

        public Team(string name, ICollection<TeamEmployee> employees) : this(name)
        {
            Employees = employees;
        }

        public string Name { get; private set; }
        public virtual ICollection<TeamEmployee> Employees { get; private set; }
        public virtual ICollection<ProjectTeam> Projects { get; private set; }

        public Team ChangeName(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
            return this;
        }

        public Team AddEmployee(long employeeId)
        {
            if (!Employees.Any(x => x.Id == employeeId))
                Employees.Add(new TeamEmployee(employeeId));

            return this;
        }

        public Team RemoveEmployee(TeamEmployee employee)
        {
            Employees.Remove(employee);
            return this;
        }
    }
}
