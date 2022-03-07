using ExamenPrueba.Data;
using ExamenPrueba.Models;
using ExamenPrueba.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Controllers
{
    public class AreasController : Controller
    {
        private readonly IAreaService _areaService;

        public AreasController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        // GET: AreasController
        public async Task<IActionResult> Index()
        {
            return View(await _areaService.GetAreas());
        }

        // GET: AreasController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var area = await _areaService.GetAreaById(id);
            if (area == null)
            {
                return NotFound();
            }
            return View(area);
        }

        // GET: AreasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AreasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Area area)
        {
            if (ModelState.IsValid)
            {
                var respModel = await _areaService.AddArea(area);
                if (respModel != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }

            return View();
        }




        // GET: AreasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _areaService.GetAreaById(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: AreasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Area area)
        {
            if (id != area.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var modelResp = await _areaService.UpdateArea(area);
                if(modelResp != null)
                return RedirectToAction(nameof(Index));
            }
            return View(area);
        }

        // POST: AreasController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _areaService.DeleteAreaById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
