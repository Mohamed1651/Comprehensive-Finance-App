using ShinyCollectorPlatform.Domain.Entities;
using ShinyCollectorPlatform.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyCollectorPlatform.Application
{
    public interface IGenericService<T> where T : IEntity
    {
        List<Course> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
