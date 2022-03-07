using ExamenPrueba.Models;
using ExamenPrueba.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Controllers
{
    public class EmpleadoHabilidadController : Controller
    {
        private readonly IEmpleadoHabilidadService _habilidadService;
        public EmpleadoHabilidadController(IEmpleadoHabilidadService habilidadService)
        {
            _habilidadService = habilidadService;
        }
        // GET: EmpleadoHabilidadController
        public async Task<IActionResult> Index(int idEmpleado)
        {
            ViewBag.idEmpleado = idEmpleado;
            return View(await _habilidadService.GetHabilidadesEmpleado(idEmpleado));
        }


        // GET: EmpleadoHabilidadController/Create
        public ActionResult Create(int idEmpleado)
        {
            ViewBag.idEmpleado = idEmpleado;
            return View();
        }

        // POST: EmpleadoHabilidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado_Habilidad habilidad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _habilidadService.AddHabilidadEmpleado(habilidad);
                    return RedirectToAction(nameof(Index), new { idEmpleado = habilidad.IdEmpleado });
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: EmpleadoHabilidadController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoHabilidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // POST: EmpleadoHabilidadController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _habilidadService.DeleteHabilidadEmpleadoById(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetHabilidadesSug()
       {
            var habilidades = await _habilidadService.GetHabilidades();
            var result = habilidades
                .Select(x => new { value = x.NombreHabilidad });
            return Json(result);
        }
    }
}
