using ExamenPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public interface IEmpleadoHabilidadService
    {
        Task<List<Empleado_Habilidad>> GetHabilidadesEmpleado(int idEmpleado);
        Task<Empleado_Habilidad> AddHabilidadEmpleado(Empleado_Habilidad area);
        Task<Empleado_Habilidad> GetHabilidadEmpleadoById(int id);
        Task<bool> DeleteHabilidadEmpleadoById(int id);
        Task<List<Empleado_Habilidad>> GetHabilidades();
    }
}
