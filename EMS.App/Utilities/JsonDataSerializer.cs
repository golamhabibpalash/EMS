using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.App.Utilities
{
    public static class JsonDataSerializer
    {
        public static string GetEventListAsString(List<Entity.Event> events)
        {
            var eventList = new List<Event>();
            foreach (var model in events)
            {
                var myEvent = new Event()
                {
                    Id = model.Id,
                    Start = model.StartTime,
                    End = model.EndTime,
                    ResourceId = model.LocationId,
                    Description = model.Description
                };
                eventList.Add(myEvent);
            }
            return System.Text.Json.JsonSerializer.Serialize(eventList);
        }
        public static string GetLocationListAsString(List<Entity.Location> locations)
        {
            var resourceList = new List<Resource>();
            foreach (var myLocation in locations)
            {
                var resource = new Resource()
                {
                    Id = myLocation.Id,
                    Name = myLocation.Name
                };
                resourceList.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourceList);
        }
    }
    public class Event
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ResourceId { get; set; }
        public string Description { get; set; }
    }
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
