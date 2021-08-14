using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Responses.EmployeeResponses;
using WorkedHourControl.Application.Utils;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IList<EmployeeResponse>> Get()
        {
            var employees = await _employeeRepository.Get();
            return employees.Select(x => x.ToResponse()).OrderBy(x => x.Name).ThenByDescending(x => x.Profile).ToList();
        }
    }
}
