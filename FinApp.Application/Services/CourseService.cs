using ShinyCollectorPlatform.Domain.Entities;
using ShinyCollectorPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyCollectorPlatform.Application.Services
{
    public class CourseService : IGenericService<Course>
    {
        private readonly IGenericRepository<Course> courseRepository;

        public CourseService(IGenericRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public List<Course> GetAll()
        {
            return this.courseRepository.GetAll();
        }

        public Task<Course> GetByIdAsync(int id)
        {
            return this.courseRepository.GetByIdAsync(id);
        }

        public Task<Course> AddAsync(Course entity)
        {
            return this.courseRepository.AddAsync(entity);
        }

        public Task UpdateAsync(Course entity)
        {
            return this.courseRepository.UpdateAsync(entity);
        }

        public Task DeleteAsync(Course entity)
        {
            return this.courseRepository.DeleteAsync(entity);
        }
    }
}
