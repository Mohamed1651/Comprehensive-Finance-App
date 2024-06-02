using ShinyCollectorPlatform.Domain.Entities;
using ShinyCollectorPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyCollectorPlatform.Infrastructure.Repositories
{
    public class CourseRepository : IGenericRepository<Course>
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Course> AddAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
