using ExamenPrueba.Data;
using ExamenPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public class EmpleadoHabilidadService : IEmpleadoHabilidadService
    {
        private readonly ExamenContext _context;
        public EmpleadoHabilidadService(ExamenContext context)
        {
            _context = context;
        }
        public async Task<Empleado_Habilidad> AddHabilidadEmpleado(Empleado_Habilidad habilidad)
        {
            try
            {
                _context.Empleado_Habilidad.Add(habilidad);
                await _context.SaveChangesAsync();
                return habilidad;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteHabilidadEmpleadoById(int id)
        {
            try
            {
                var habilidad = await GetHabilidadEmpleadoById(id);
                _context.Empleado_Habilidad.Remove(habilidad);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Empleado_Habilidad>> GetHabilidades()
        {
            return await _context.Empleado_Habilidad.ToListAsync();
        }
        public async Task<Empleado_Habilidad> GetHabilidadEmpleadoById(int id)
        {
            return await _context.Empleado_Habilidad.FirstOrDefaultAsync(x => x.IdHabilidad == id);
        }

        public async Task<List<Empleado_Habilidad>> GetHabilidadesEmpleado(int idEmpleado)
        {
            return await _context.Empleado_Habilidad.Where(x => x.IdEmpleado == idEmpleado).ToListAsync();
        }
    }
}
