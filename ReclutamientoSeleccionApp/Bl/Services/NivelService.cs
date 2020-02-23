using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class NivelService : BaseRepository<Nivel>
    {
        public async Task<IQueryable<Nivel>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Niveles.Where(x => !x.Deleted).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfHasCapacitaciones(int departamentoId)
        {
            return await Task.Run(() => {
                return _context.Capacitaciones.Any(x => !x.Deleted && x.NivelId == departamentoId);
            });
        }

        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Niveles.Any(x => !x.Deleted && x.Titulo.ToLower().Trim() == name.ToLower().Trim());
            });
        }
        public async Task<IQueryable<Nivel>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Niveles.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
        public IQueryable<Nivel> GetIdiomaByCriteria(string criterio)
        {
            return _context.Niveles.Where(x => !x.Deleted && x.Titulo.ToLower().Contains(criterio.ToLower())).AsQueryable();
        }
    }
}
