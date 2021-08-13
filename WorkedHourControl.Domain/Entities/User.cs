using WorkedHourControl.Domain.Entities.Base;

namespace WorkedHourControl.Domain.Entities
{
    public class User : EntityBase
    {
        public User()
        {
        }

        public User(string username, string password, string name, Profile profile)
        {
            Username = username;
            Password = password;
            Employee = new Employee(name, profile);
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public long EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }
    }
}
