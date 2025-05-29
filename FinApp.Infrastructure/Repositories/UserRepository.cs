using FinApp.Domain.Aggregates;
using FinApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinApp.Infrastructure.Repositories
{
    public class UserRepository : IRepository<UserAggregate>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserAggregate entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserAggregate entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserAggregate>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserAggregate> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task UpdateAsync(UserAggregate entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
