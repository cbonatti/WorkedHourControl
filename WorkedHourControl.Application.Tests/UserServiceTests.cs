using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests;
using WorkedHourControl.Application.Services.UserServices;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _service;

        [TestInitialize]
        public void Initialize()
        {
            var repo = new Mock<IUserRepository>();
            var user = new User("gestor", "123", "Gestor", Profile.Manager);
            repo.Setup(x => x.Get(1)).ReturnsAsync(user);
            repo.Setup(x => x.Get("gestor")).ReturnsAsync(user);

            _service = new UserService(repo.Object);
        }

        [TestMethod]
        public async Task Should_Get_User_1()
        {
            var user = await _service.Get(1);
            user.Name.Should().Be("Gestor");
        }

        [TestMethod]
        public async Task Should_Not_Get_User_2()
        {
            var user = await _service.Get(2);
            user.Should().BeNull();
        }

        [TestMethod]
        public async Task Should_Not_Add_When_User_Exists()
        {
            var req = new AddUserRequest()
            {
                Name = "Gestor",
                Password = "123",
                Username = "gestor",
                Profile = Profile.Manager
            };

            var user = await _service.Add(req);
            user.Should().BeNull();
        }

        [TestMethod]
        public async Task Should_Add_New_User()
        {
            var req = new AddUserRequest()
            {
                Name = "Carlos",
                Password = "123",
                Username = "carlos",
                Profile = Profile.Employee
            };

            var user = await _service.Add(req);
            user.Name.Should().Be("Carlos");
            user.Profile.Name.Should().Be("Colaborador");
        }

        [TestMethod]
        public async Task Should_Update_User()
        {
            var req = new UpdateUserRequest()
            {
                Id = 1,
                Name = "Gestor 2",
                Username = "username can not change",
                Profile = Profile.Manager
            };

            var user = await _service.Update(req);
            user.Name.Should().Be("Gestor 2");
            user.Username.Should().Be("gestor");
        }

        [TestMethod]
        public async Task Should_Not_Update_When_User_Not_Found()
        {
            var req = new UpdateUserRequest()
            {
                Id = 5,
                Name = "Gestor 2",
                Username = "username can not change",
                Profile = Profile.Manager
            };

            var user = await _service.Update(req);
            user.Should().BeNull();
        }
    }
}
