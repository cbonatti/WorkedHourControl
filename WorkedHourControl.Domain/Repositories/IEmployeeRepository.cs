using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;

namespace WorkedHourControl.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(long id);
        //Task<IList<Employee>> Get();
    }
}
