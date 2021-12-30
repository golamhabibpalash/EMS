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
    public class LocationService : BaseService<Location>, ILocationService
    {
        public LocationService(ILocationRepository locationRepository) : base(locationRepository)
        {

        }
    }
}
