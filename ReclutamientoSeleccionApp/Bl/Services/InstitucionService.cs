using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class InstitucionService : BaseRepository<Institucion>
    {
        public async Task<IQueryable<Institucion>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Instituciones.Where(x => !x.Deleted).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfHasCapacitaciones(int departamentoId)
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Any(x => !x.Deleted && x.InstitucionId == departamentoId);
            });
        }
        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Instituciones.Any(x => !x.Deleted && x.NombreInstitucion.ToLower().Trim() == name.ToLower().Trim());
            });
        }
        public async Task<IQueryable<Institucion>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Instituciones.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
    }
}
