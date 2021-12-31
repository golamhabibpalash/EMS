using EMS.App.Models;
using EMS.App.Utilities;
using EMS.BLL.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.App.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;
        private readonly ILocationService _locationService;
        private readonly IEventService _eventService;

        public HomeController(ILogger<HomeController> logger, ILocationService locationService, IEventService eventService)
        {
            _logger = logger;
            _locationService = locationService;
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllAsync();
            var upComingEvents = events.Where(e => e.StartTime > DateTime.Now).ToList();
            var runningEvents = events.Where(e => e.StartTime < DateTime.Now && e.EndTime > DateTime.Now).ToList();
            ViewBag.upComingEvents = upComingEvents;
            ViewBag.runningEvents = runningEvents;
            return View();
        }
        public async Task<IActionResult> Calendar()
        {
            ViewData["Resources"] = JsonDataSerializer.GetLocationListAsString(await _locationService.GetAllAsync());
            ViewData["Events"] = JsonDataSerializer.GetEventListAsString(await _eventService.GetAllAsync());
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
