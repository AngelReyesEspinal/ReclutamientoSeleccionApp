using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class CapacitacionService : BaseRepository<Capacitacion>
    {
        public async Task<IQueryable<Capacitacion>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Where(x => !x.Deleted).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Any(x => !x.Deleted && x.Descripcion.ToLower().Trim() == name.ToLower().Trim());
            });
        }
        public async Task<IQueryable<Capacitacion>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
        public async Task<IQueryable<Capacitacion>> GetActiveByPuesto(int puestoId)
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Where(x => !x.Deleted && x.PuestoId == puestoId).AsQueryable();
            });
        }
    }
}
