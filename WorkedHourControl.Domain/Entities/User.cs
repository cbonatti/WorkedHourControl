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

        public User(long id, string username, string password, Employee employee)
        {
            SetId(id);
            Username = username;
            Password = password;
            EmployeeId = employee.Id;
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public long EmployeeId { get; private set; }
        public virtual Employee Employee { get; private set; }

        public User ChangePassword(string password)
        {
            if (!string.IsNullOrEmpty(password))
                Password = password;
            return this;
        }
    }
}
