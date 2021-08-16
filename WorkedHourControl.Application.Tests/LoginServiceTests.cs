using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using WorkedHourControl.Application.Services.UserServices;
using WorkedHourControl.Domain.Entities;
using WorkedHourControl.Domain.Repositories;
using WorkedHourControl.Infra.Authorization;

namespace WorkedHourControl.Application.Tests
{
    [TestClass]
    public class LoginServiceTests
    {
        private LoginService _service;

        [TestInitialize]
        public void Initialize()
        {
            var tokenService = new Mock<ITokenService>();
            tokenService.Setup(x => x.GenerateToken(It.IsAny<string>(), It.IsAny<string>())).Returns("tokenmuitobemseguro");
            var repo = new Mock<IUserRepository>();
            repo.Setup(x => x.Login("gestor", "123")).ReturnsAsync(new User("gestor", "123", "Gestor", Profile.Manager));
            _service = new LoginService(repo.Object, tokenService.Object);
        }

        [TestMethod]
        public async Task Should_Not_Login()
        {
            var user = await _service.Login(new DTOs.Requests.LoginRequest() { Username = "gestor", Password = "1234" });
            user.Should().BeNull();
        }

        [TestMethod]
        public async Task Should_Login()
        {
            var user = await _service.Login(new DTOs.Requests.LoginRequest() { Username = "gestor", Password = "123" });
            user.Should().NotBeNull();
            user.Token.Should().Be("tokenmuitobemseguro");
            user.Username.Should().Be("gestor");
        }
    }
}
