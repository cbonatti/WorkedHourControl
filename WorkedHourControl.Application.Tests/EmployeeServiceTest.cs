using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.Services.EmployeeServices;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Tests
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private EmployeeService _service;

        [TestInitialize]
        public void Initialize()
        {
            var repo = new Mock<IEmployeeRepository>();
            repo.Setup(x => x.Get()).ReturnsAsync(new List<Employee>()
            {
                new Employee(1, "Manager", Profile.Manager),
                new Employee(2, "Employee", Profile.Employee)
            });

            _service = new EmployeeService(repo.Object);
        }

        [TestMethod]
        public async Task Should_Return_Two_Employees()
        {
            var employees = await _service.Get();
            employees.Count.Should().Be(2);
        }
    }
}
