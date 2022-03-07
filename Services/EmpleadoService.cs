using ExamenPrueba.Data;
using ExamenPrueba.Helpers;
using ExamenPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly ExamenContext _context;
        public EmpleadoService(ExamenContext context)
        {
            _context = context;
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            return await _context.Empleado
                .Include( x => x.IdAreaNavigation)
                .Include(x => x.IdJefeNavigation)
                .ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosByArea(int area)
        {

            if(area != 0)
            {
                var data = await GetEmpleados();
                return data.Where(s => s.IdArea == area).ToList();
            }
            else
            {
                return await GetEmpleados();
            }
        }
        public async Task<Empleado> AddEmpleado(Empleado empleado)
        {
            try
            {

                empleado.Foto = HeperImage.ConvertFileToByte(empleado.FotoFile);
                if (empleado.IdJefe == 0)
                {
                    empleado.IdJefe = null;
                }
                _context.Empleado.Add(empleado);
                await _context.SaveChangesAsync();
                return empleado;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteEmpleadoById(int id)
        {
            try
            {
                var empleado = await GetEmpleadoById(id);
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Empleado> GetEmpleadoById(int id)
        {
            var empleado = await _context.Empleado
                .Include(x => x.IdAreaNavigation)
                .Include(x => x.IdJefeNavigation)
                .FirstOrDefaultAsync(x => x.IdEmpleado == id);
            if (empleado != null && empleado.IdJefe == null) { empleado.IdJefe = 0; }
            return empleado;

        }

        public async Task<Empleado> UpdateEmpleado(Empleado empleado)
        {
            try
            {
                if(empleado.FotoFile != null)
                {
                    empleado.Foto = HeperImage.ConvertFileToByte(empleado.FotoFile);
                }
                if(empleado.IdJefe == 0)
                {
                    empleado.IdJefe = null;
                }
                _context.Empleado.Update(empleado);
                await _context.SaveChangesAsync();
                return empleado;
            }
            catch
            {
                return null;
            }
        }
    }
}
