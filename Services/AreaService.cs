using ExamenPrueba.Data;
using ExamenPrueba.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenPrueba.Services
{
    public class AreaService : IAreaService
    {
        private readonly ExamenContext _context;
        public AreaService(ExamenContext context)
        {
            _context = context;
        }
        public async Task<List<Area>> GetAreas()
        {
            return await _context.Area.ToListAsync();
        }
        public async Task<Area> AddArea(Area area)
        {
            try
            {
                _context.Area.Add(area);
                await _context.SaveChangesAsync();
                return area;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteAreaById(int id)
        {
            try
            {
                var area = await GetAreaById(id);
                _context.Area.Remove(area);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Area> GetAreaById(int id)
        {
            return await _context.Area.FirstOrDefaultAsync(x => x.IdArea == id);
        }


        public async Task<Area> UpdateArea(Area area)
        {
            try
            {
                _context.Area.Update(area);
                await _context.SaveChangesAsync();
                return area;
            }
            catch
            {
                return null;
            }
        }
    }
}
