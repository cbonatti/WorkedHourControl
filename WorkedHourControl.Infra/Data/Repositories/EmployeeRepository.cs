using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Infra.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly WorkedHourContext _context;

        public EmployeeRepository(WorkedHourContext context)
        {
            _context = context;
        }

        public async Task<Employee> Get(long id) => await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);

        //public async Task<IList<Employee>> Get() => await _context.Employees.ToListAsync();
    }
}
