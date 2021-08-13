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
            Name = name;
            return this;
        }

        public Team AddEmployee(Employee employee)
        {
            if (Employees == null)
                Employees = new List<TeamEmployee>();

            if (!Employees.Any(x => x.Id == employee.Id))
                Employees.Add(new TeamEmployee(employee.Id));

            return this;
        }

        public Team RemoveEmployee(Employee employee)
        {
            var teamEmployee = Employees.FirstOrDefault(x => x.EmployeeId == employee.Id);
            Employees.Remove(teamEmployee);
            return this;
        }
    }
}
