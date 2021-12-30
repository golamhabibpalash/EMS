using EMS.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.App.ViewModel
{
    public class EventVM
    {
        public Event Event { get; set; }
        public List<SelectListItem> Location { get; set; }
        public string LocationName { get; set; }

        public EventVM(Event myEvent, List<Location> locations)
        {
            Event = myEvent;
            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() { Text = loc.Name });
            }
        }

        public EventVM(List<Location> locations)
        {
            foreach (var loc in locations)
            {
                Location.Add(new SelectListItem() { Text = loc.Name });
            }
        }
    }
}
