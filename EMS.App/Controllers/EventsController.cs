using EMS.App.ViewModel;
using EMS.BLL.IService;
using EMS.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.App.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;

        public EventsController(IEventService eventService, ILocationService locationService)
        {
            _eventService = eventService;
            _locationService = locationService;
        }
        

        public async Task<ActionResult> Index()
        {
            return View(await _eventService.GetAllAsync());
        }


        public async Task<ActionResult> Details(int id)
        {
            var existingEvent = await _eventService.GetByIdAsync(id);
            return View(existingEvent);
        }


        public async Task<ActionResult> Create()
        {
            ViewBag.LocationList = new SelectList(await _locationService.GetAllAsync(), "Id", "Name");
            return View();
        }


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
            ViewBag.LocationList = new SelectList(await _locationService.GetAllAsync(), "Id", "Name", model.LocationId);
            return View(model);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var existingEvent = await _eventService.GetByIdAsync(id);
            if (existingEvent != null)
            {

                ViewBag.LocationList = new SelectList(await _locationService.GetAllAsync(), "Id", "Name", existingEvent.LocationId);
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
                var isUpdated = await _eventService.UpdateAsync(model);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.LocationList = new SelectList(await _locationService.GetAllAsync(), "Id", "Name", model.LocationId);
            return View(model);
        }


        public async Task<ActionResult> Delete(int id)
        {
            return View(await _eventService.GetByIdAsync(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,Event model ,IFormCollection collection)
        {
            try
            {
                var isDeleted = await _eventService.RemoveAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
