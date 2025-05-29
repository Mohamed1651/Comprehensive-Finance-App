using FinApp.Application.Dtos;
using FinApp.Domain.Aggregates;


namespace FinApp.Application.Interfaces
{
    public interface IUserService
    {
        public Task<UserAggregate> GetCurrentUser();
        public Task<IEnumerable<UserAggregate>> GetUsers();
        public Task<UserAggregate> GetUser(int id);
        public Task<UserAggregate> CreateUser(UserDto value);
        public Task UpdateUser(UserDto value);
        public Task DeleteUser(int id);
    }
}
