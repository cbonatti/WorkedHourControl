using System.Collections.Generic;
using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class Employee : EntityBase
    {
        public Employee()
        {
        }

        public Employee(string name, Profile profile)
        {
            Name = name;
            Profile = profile;
        }

        public Employee(long id, string name, Profile profile) : this(name,profile)
        {
            SetId(id);
        }

        public string Name { get; private set; }
        public Profile Profile { get; private set; }
        public virtual ICollection<TeamEmployee> Teams { get; private set; }

        public Employee ChangeName(string name)
        {
            Name = name;
            return this;
        }
    }
}
