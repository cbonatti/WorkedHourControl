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

        public Team(string name, ICollection<Employee> employees) : this(name)
        {
            Employees = employees;
        }

        public string Name { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; }

        public Team ChangeName(string name)
        {
            Name = name;
            return this;
        }

        public Team AddEmployee(Employee employee)
        {
            if (Employees == null)
                Employees = new List<Employee>();

            if (!Employees.Any(x => x.Id == employee.Id))
                Employees.Add(employee);

            return this;
        }

        public Team RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
            return this;
        }
    }
}
