using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkedHourControl.Application.DTOs.Requests.TeamRequests;
using WorkedHourControl.Application.Services.TeamServices;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;

namespace WorkedHourControl.Application.Tests
{
    [TestClass]
    public class TeamServiceTests
    {
        private TeamService _service;

        [TestInitialize]
        public void Initialize()
        {
            var repo = new Mock<ITeamRepository>();
            repo.Setup(x => x.Get()).ReturnsAsync(new List<Team>()
            {
                new Team(1, "Team 4"),
                new Team(2, "Team 1")
            });

            repo.Setup(x => x.Get(1)).ReturnsAsync(new Team("Team 1", new List<TeamEmployee>()));
            repo.Setup(x => x.Get(2)).ReturnsAsync(new Team("Team 2", new List<TeamEmployee>()
            {
                new TeamEmployee(1),
                new TeamEmployee(3)
            }));

            _service = new TeamService(repo.Object);
        }

        [TestMethod]
        public async Task Should_Return_Two_Teams()
        {
            var teams = await _service.Get();
            teams.Count.Should().Be(2);
            teams[0].Name.Should().Be("Team 1");
            teams[0].Id.Should().Be(2);
        }

        [TestMethod]
        public async Task Should_Get_Team_1()
        {
            var team = await _service.Get(1);
            team.Name.Should().Be("Team 1");
            team.Employees.Count.Should().Be(0);
        }

        [TestMethod]
        public async Task Should_Add_New_Team()
        {
            var req = new AddTeamRequest()
            {
                Name = "Team 1",
                Employees = new int[] { 1, 2 }
            };

            var team = await _service.Add(req);
            team.Name.Should().Be("Team 1");
            team.Employees.Count.Should().Be(2);
        }

        [TestMethod]
        public async Task Should_Update_Team()
        {
            var req = new UpdateTeamRequest()
            {
                Id = 1,
                Name = "Team 2",
                Employees = new int[] { 1, 2 }
            };

            var team = await _service.Update(req);
            team.Name.Should().Be("Team 2");
            team.Employees.Count.Should().Be(2);
        }

        [TestMethod]
        public async Task Should_Update_Team_Merging_Employees()
        {
            var req = new UpdateTeamRequest()
            {
                Id = 2,
                Name = "Team 3",
                Employees = new int[] { 1, 2 }
            };

            var team = await _service.Update(req);
            team.Name.Should().Be("Team 3");
            team.Employees.Count.Should().Be(2);
        }

        [TestMethod]
        public async Task Should_Not_Update_When_Team_Not_Found()
        {
            var req = new UpdateTeamRequest()
            {
                Id = 5,
                Name = "Team 3",
                Employees = new int[] { 1, 2 }
            };

            var team = await _service.Update(req);
            team.Should().BeNull();
        }
    }
}
