using FinApp.Domain.Entities;
using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUser(int id);
        public Task CreateUser(User value);
        public Task UpdateUser(User value);
        public Task DeleteUser(int id);
    }
}
