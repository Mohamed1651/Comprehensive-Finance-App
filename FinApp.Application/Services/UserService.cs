using FinApp.Application.Interfaces;
using FinApp.Domain.Entities;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IGenericRepository<User> userRepository, IHttpContextAccessor httpContextAccessor) 
        { 
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserId =>
            _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value;

        public bool IsAuthenticated =>
            _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true;       
     
        public Task<IEnumerable<User>> GetUsers()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task CreateUser(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUser(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with ID {user.Id} not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            await _userRepository.UpdateAsync(existingUser);
        }
        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }

        public Task<User> GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
