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
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public async Task<ActionResult> Index()
        {
            var locations = await _locationService.GetAllAsync();
            return View(locations);
        }


        public async Task<ActionResult> Details(int id)
        {
            return View(await _locationService.GetByIdAsync(id));
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location model, IFormCollection collection)
        {
            try
            {
                var isSaved = await _locationService.AddAsync(model);
                if (isSaved)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
            return View(model);
        }

        // GET: LocationsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View(await _locationService.GetByIdAsync(id));
        }

        // POST: LocationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Location model, IFormCollection collection)
        {
            try
            {
                var isUpdated = await _locationService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View(model);
            }
        }

        // GET: LocationsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View(await _locationService.GetByIdAsync(id));
        }

        // POST: LocationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Location model, IFormCollection collection)
        {
            try
            {
                var isDeleted = await _locationService.RemoveAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View(model);
            }
        }
    }
}
