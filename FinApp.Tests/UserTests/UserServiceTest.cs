using FinApp.Application.Interfaces;
using FinApp.Application.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using Xunit;
using System.Threading.Tasks;
using FinApp.Domain.Interfaces;
using FinApp.Domain.Entities;

namespace FinApp.Tests.UserTests
{
    public class UserServiceTest
    {
        private readonly Mock<IRepository<User>> _userRepositoryMock = new();
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new();
        private readonly UserService _userService;

        public UserServiceTest()
        {
            // Set up mock HttpContext with fake user
            var claims = new[] { new Claim("sub", "test-user-id") };
            var identity = new ClaimsIdentity(claims, "mock");
            var principal = new ClaimsPrincipal(identity);

            var httpContext = new DefaultHttpContext
            {
                User = principal
            };

            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(httpContext);

            _userService = new UserService(_userRepositoryMock.Object, _httpContextAccessorMock.Object);
        }

        [Fact]
        public async Task CreateUser_WithValidData_ReturnsNewUser()
        {
            // Arrange
            var user = new User("Sam", "sam@example.com");

            _userRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask); // Mimic repository returning the same user

            // Act
            var result = await _userService.CreateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Sam", result.Name);
            Assert.Equal("sam@example.com", result.Email);
        }
    }
}
