using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class PuestoService : BaseRepository<Puesto>
    {
        public async Task<IQueryable<Puesto>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Puestos.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
    }
}
