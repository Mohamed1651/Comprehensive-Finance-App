using AutoMapper;
using FinApp.Application.Commands.CreateUser;
using FinApp.Application.Dtos;
using FinApp.Application.Queries.GetUserById;
using FinApp.Application.Queries.GetUserByUid;
using FinApp.Application.Queries.GetUsers;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using FinApp.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace FinApp.Tests.UserTests
{
    public class UserTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly CreateUserHandler _createuserhandler;
        private readonly GetUserByUidHandler _getuserbyuidhandler;
        private readonly GetUserByIdHandler _getuserbyidhandler;
        private readonly GetUsersHandler _getusershandler;
        public UserTests()
        {
            _createuserhandler = new CreateUserHandler(_mapperMock.Object, _userRepositoryMock.Object);
            _getuserbyuidhandler = new GetUserByUidHandler(_userRepositoryMock.Object);
            _getuserbyidhandler = new GetUserByIdHandler(_mapperMock.Object, _userRepositoryMock.Object);
            _getusershandler = new GetUsersHandler(_mapperMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_UserExists_ReturnsExistingUserDto()
        {
            //Arrange
            var dto = new UserDto(0, "uid-123", "Test User", "test@example.com");

            var existingUser = new UserAggregate("uid-123", "Test User", "test@example.com", new Settings(1, "en", false, false));

            _userRepositoryMock.Setup(r => r.GetByUidAsync("uid-123")).ReturnsAsync(existingUser);
            _mapperMock.Setup(m => m.Map<UserDto>(existingUser)).Returns(dto);

            var command = new CreateUserCommand(dto);

            //Act
            var result = await _createuserhandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.Equal(dto.Uid, result.Uid);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Email, result.Email);

            _userRepositoryMock.Verify(r => r.AddAsync(It.IsAny<UserAggregate>()), Times.Never);
            _userRepositoryMock.Verify(r => r.GetByUidAsync("uid-123"), Times.Once);
        }

        [Fact]
        public async Task Handle_UserDoesNotExist_CreatesNewUserAndReturnsDto()
        {
            //Arrange
            var dto = new UserDto(0, "uid-456", "New User", "newUser@example.com");
            _userRepositoryMock.Setup(r => r.GetByUidAsync(dto.Uid)).ReturnsAsync((UserAggregate)null!);
            var newUser = new UserAggregate(dto.Uid, dto.Name, dto.Email, new Settings(1, "en", false, false));
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<UserAggregate>())).Returns(dto);
            var command = new CreateUserCommand(dto);

            //Act
            var result = await _createuserhandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.Equal(dto.Uid, result.Uid);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Email, result.Email);

            _userRepositoryMock.Verify(r => r.AddAsync(It.Is<UserAggregate>(u => u.Uid == dto.Uid && u.Name == dto.Name && u.Email.EqualsString(dto.Email))), Times.Once);
        }

        [Fact]
        public async Task Retrieve_UserByUid_ReturnsUserId_WhenUserExists()
        {
            // Arrange
            var uid = "uid-789";
            var query = new GetUserByUidQuery(uid);
            var userAggregate = new UserAggregate(uid, "Test User", "a@a.nl", new Settings(1, "en", false, false));

            _userRepositoryMock.Setup(r => r.GetByUidAsync(uid))
                .ReturnsAsync(userAggregate);

            // Act
            var result = await _getuserbyuidhandler.Handle(query, default);

            // Assert
            Assert.Equal(result, 0);
        }

        [Fact]
        public async Task Retrieve_UserById_ReturnsUserDto_WhenUserExists()
        {
            // Arrange
            var id = 0;
            var query = new GetUserByIdQuery(id);
            var userAggregate = new UserAggregate("uid-789", "Test User", "a@a.nl", new Settings(1, "en", false, false));
            var userDto = new UserDto(id, "uid-789", "Test User", "a@a.nl");
            _mapperMock.Setup(m => m.Map<UserDto>(It.IsAny<UserAggregate>())).Returns(userDto);
            _userRepositoryMock.Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(userAggregate);

            // Act
            var result = await _getuserbyidhandler.Handle(query, default);

            // Assert
            Assert.Equal(userDto.Id, result.Id);
            Assert.Equal(userDto.Uid, result.Uid);
            Assert.Equal(userDto.Name, result.Name);
            Assert.Equal(userDto.Email, result.Email);
        }

        [Fact]
        public async Task Retrieve_AllUsers_ReturnsListUserDto_WhenUsersExists()
        {
            // Arrange
            List<UserDto> userDtos = new List<UserDto>
            {
                new UserDto(0, "uid-789", "Test User", "a@a.nl"),
                new UserDto(1, "uid-790", "Another User", "b@b.nl")
            };

            List<UserAggregate> userAggregates = new List<UserAggregate>
            {
                new UserAggregate("uid-789", "Test User", "a@a.nl", new Settings(1, "en", false, false)),
                new UserAggregate("uid-790", "Another User", "b@b.nl", new Settings(1, "en", false, false))
            };

            _userRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(userAggregates);
            _mapperMock.Setup(m => m.Map<List<UserDto>>(It.IsAny<List<UserAggregate>>())).Returns(userDtos);

            GetUsersQuery query = new GetUsersQuery();

            // Act
            var result = await _getusershandler.Handle(query, default);

            // Assert
            Assert.Equal(userDtos.Count, result.Count);

            for (int i = 0; i < userDtos.Count; i++)
            {
                Assert.Equal(userDtos[i].Id, result[i].Id);
                Assert.Equal(userDtos[i].Uid, result[i].Uid);
                Assert.Equal(userDtos[i].Name, result[i].Name);
                Assert.Equal(userDtos[i].Email, result[i].Email);
            }
        }
    }
}
