using FinApp.Application.Dtos;
using FinApp.Application.Interfaces;
using FinApp.Domain.Aggregates;
using FinApp.Domain.Entities;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FinApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserAggregate> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IRepository<UserAggregate> userRepository, IHttpContextAccessor httpContextAccessor) 
        { 
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserId =>
            _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? "";

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;       
     
        public Task<IEnumerable<UserAggregate>> GetUsers()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task<UserAggregate> GetUser(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<UserAggregate> CreateUser(UserDto user)
        {
            Settings settings = new Settings("en",false,false);
            var newUser = new UserAggregate(UserId, user.Name, user.Email, settings);
            await _userRepository.AddAsync(newUser);
            return newUser;
        }

        public async Task UpdateUser(UserDto user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with ID {user.Id} not found.");
            }

            existingUser.UpdateName(user.Name);
            existingUser.UpdateEmail(user.Email);

            await _userRepository.UpdateAsync(existingUser);
        }
        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public async Task<UserAggregate> GetCurrentUser()
        {
            var userId = UserId;
            if (string.IsNullOrEmpty(userId))
                throw new UserNotFoundException("User ID clain not found.");

            var allUser = await _userRepository.GetAllAsync();
            var user = allUser.FirstOrDefault(u => u.Uid == userId);

            if (user != null)
                return user;

            var name = _httpContextAccessor.HttpContext?.User?.FindFirst("name")?.Value ?? "";
            var email = _httpContextAccessor.HttpContext?.User.FindFirst("email")?.Value ?? "";

            var newUser = new UserAggregate(userId, name, email, new Settings("en", false, false));
            await _userRepository.AddAsync(newUser);

            return newUser;
        }
    }
}
