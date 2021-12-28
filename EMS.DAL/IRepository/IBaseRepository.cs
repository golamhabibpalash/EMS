using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.IRepository
{
    public interface IBaseRepository<T> where T:class
    {
        Task<bool> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(T entity);
    }
}
