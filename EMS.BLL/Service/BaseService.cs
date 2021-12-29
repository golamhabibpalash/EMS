using EMS.BLL.IService;
using EMS.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Service
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> AddAsync(T entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _baseRepository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _baseRepository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            return await _baseRepository.RemoveAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
