using FinApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinApp.Application.Interfaces
{
    public interface IGenericService<T>
    {
        public Task<IEnumerable<T>> Get();
        public Task<T> Get(int id);
        public Task Post(T value);
        public Task Put(T value);
        public Task Delete(int id);
    }
}
