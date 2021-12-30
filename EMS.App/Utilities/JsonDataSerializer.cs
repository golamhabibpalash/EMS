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
                    id = model.Id,
                    start = model.StartTime,
                    end = model.EndTime,
                    resourceId = model.LocationId,
                    description = model.Description
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
                    id = myLocation.Id,
                    title = myLocation.Name
                };
                resourceList.Add(resource);
            }
            return System.Text.Json.JsonSerializer.Serialize(resourceList);
        }
    }
    public class Event
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int resourceId { get; set; }
        public string description { get; set; }
    }
    public class Resource
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
