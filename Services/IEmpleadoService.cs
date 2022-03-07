using ExamenPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public interface IEmpleadoService
    {
        Task<List<Empleado>> GetEmpleados();
        Task<List<Empleado>> GetEmpleadosByArea(int area);
        Task<Empleado> AddEmpleado(Empleado empleado);
        Task<Empleado> GetEmpleadoById(int id);
        Task<Empleado> UpdateEmpleado(Empleado empleado);
        Task<bool> DeleteEmpleadoById(int id);
    }
}
