using ExamenPrueba.Helpers;
using ExamenPrueba.Models;
using ExamenPrueba.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoService _empleado;
        private readonly IAreaService _area;

        public EmpleadosController(IEmpleadoService empleado, IAreaService area)
        {
            _empleado = empleado;
            _area = area;
        }
        // GET: EmpleadosController
        public async Task<IActionResult> Index(int area)
        {
            List<Area> areasList = await _area.GetAreas();
            areasList.Add(new Area { IdArea = 0, Nombre = "Todas" });
            ViewBag.Areas = new SelectList(areasList, "IdArea", "Nombre", area);

            return View(await _empleado.GetEmpleadosByArea(area));
        }


        // GET: EmpleadosController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await _empleado.GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }

            ViewBag.Edad = HelperDateTime.GetAge(empleado.FechaNacimiento).Year;
            ViewBag.TLaborando = HelperDateTime.GetAge(empleado.FechaIngreso).Year;

            ViewBag.FotoUrl = HeperImage.GetUrl(empleado.Foto);
            return View(empleado);
        }

        // GET: EmpleadosController/Create
        public async Task<IActionResult> Create()
        {
            List<Empleado> empleadosList = await _empleado.GetEmpleados();
            empleadosList.Add(new Empleado { IdEmpleado = 0, NombreCompleto = "Ninguno" });

            ViewBag.Areas = new SelectList(await _area.GetAreas(), "IdArea", "Nombre");
            ViewBag.Empleados = new SelectList(empleadosList, "IdEmpleado", "NombreCompleto");
            return View();
        }

        // POST: EmpleadosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _empleado.AddEmpleado(empleado);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: EmpleadosController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var empleado = await _empleado.GetEmpleadoById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            List<Area> areasList = await _area.GetAreas();
            List<Empleado> empleadosList = await _empleado.GetEmpleados();
            
            areasList.Add(new Area { IdArea = 0, Nombre = "Ninguna" });
            empleadosList.Add(new Empleado { IdEmpleado = 0, NombreCompleto = "Ninguno" });

            ViewBag.Areas = new SelectList(areasList, "IdArea", "Nombre", empleado.IdArea);
            ViewBag.Empleados = new SelectList(empleadosList, "IdEmpleado", "NombreCompleto", empleado.IdJefe);

            ViewBag.FotoUrl = HeperImage.GetUrl(empleado.Foto);

            return View(empleado);
        }

        // POST: EmpleadosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var modelResp = await _empleado.UpdateEmpleado(empleado);
                if (modelResp != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // POST: AreasController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _empleado.DeleteEmpleadoById(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> TreeEmpleados()
        {
            var lstEmpleados = await _empleado.GetEmpleados();
            var jefes = lstEmpleados.Where(x => x.IdJefe == null).ToList();

            return View(jefes);
            
        }

    }
}
