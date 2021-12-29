using EMS.BLL.IService;
using EMS.DAL.IRepository;
using EMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BLL.Service
{
    public class EventService : BaseService<Event>, IEventService
    {
        public EventService(IEventRepository eventRepository):base(eventRepository)
        {

        }
    }
}
