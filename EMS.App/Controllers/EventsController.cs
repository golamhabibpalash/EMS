using EMS.App.ViewModel;
using EMS.BLL.IService;
using EMS.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }
        
        // GET: EventsController
        public async Task<ActionResult> Index()
        {
            return View(await _eventService.GetAllAsync());
        }

        // GET: EventsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var existingEvent = await _eventService.GetByIdAsync(id);
            return View(existingEvent);
        }

        // GET: EventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Event model)
        {
            if (ModelState.IsValid)
            {
                var isAdded = await _eventService.AddAsync(model);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: EventsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var existingEvent = await _eventService.GetByIdAsync(id);
            if (existingEvent != null)
            {
                return View(existingEvent);
            }
            ViewBag.msg = "Not found";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Event model)
        {
            if (id != model.Id)
            {
                return View();
            }
            if (ModelState.IsValid)
            {

            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
