using ExamenPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public interface IAreaService
    {
        Task<List<Area>> GetAreas();
        Task<Area> AddArea(Area area);
        Task<Area> GetAreaById(int id);
        Task<Area> UpdateArea(Area area);
        Task<bool> DeleteAreaById(int id);
    }
}
