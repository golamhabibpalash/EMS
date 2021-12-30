using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMS.DAL.IRepository;
using EMS.DB;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table { get { return _context.Set<T>(); } }
        public virtual async Task<bool> AddAsync(T entity)
        {
            Table.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> RemoveAsync(T entity)
        {
            Table.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Table.FirstAsync();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
