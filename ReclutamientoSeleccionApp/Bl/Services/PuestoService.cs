using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class PuestoService : BaseRepository<Puesto>
    {
        public async Task<IQueryable<Puesto>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Puestos.Where(x => !x.Deleted).AsQueryable();
            });
        }

        public async Task<IQueryable<Puesto>> GetActiveRecords()
        {
            return await Task.Run(() => {
                return _context.Puestos.Where(x => !x.Deleted && x.Estado == Models.Codes.Estado.Activo).AsQueryable();
            });
        }

        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Puestos.Any(x => !x.Deleted && x.Nombre.ToLower().Trim() == name.ToLower().Trim());
            });
        }

        public async Task<IQueryable<Puesto>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Puestos.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
    }
}
