using FinApp.Application.Interfaces;
using FinApp.Domain.Entities;
using FinApp.Domain.Exceptions;
using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Services
{
    public class UserService : IGenericService<User>
    {
        private readonly IGenericRepository<User> _userRepository;
        public UserService(IGenericRepository<User> userRepository) 
        { 
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> Get()
        {
            return _userRepository.GetAllAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task Post(User value)
        {
            await _userRepository.AddAsync(value);
        }

        public async Task Put(User value)
        {
            var existingUser = await _userRepository.GetByIdAsync(value.Id);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with ID {value.Id} not found.");
            }

            existingUser.Name = value.Name;
            existingUser.Email = value.Email;
            existingUser.Password = value.Password;

            await _userRepository.UpdateAsync(existingUser);
        }
        public async Task Delete(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }
    }
}
