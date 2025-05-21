using FinApp.Domain.Interfaces;
using FinApp.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetCurrentUser();
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(int id);
        public Task<User> CreateUser(User value);
        public Task UpdateUser(User value);
        public Task DeleteUser(int id);
    }
}
