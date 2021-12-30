using EMS.DAL.IRepository;
using EMS.DB;
using EMS.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DAL.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }
        public override async Task<List<Event>> GetAllAsync()
        {
            return await _context.Events.Include(e => e.Location).ToListAsync();
        }
    }
}
