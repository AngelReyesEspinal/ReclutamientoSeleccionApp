using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class DepartamentoService : BaseRepository<Departamento>
    {
        public async Task<IQueryable<Departamento>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Departamentos.Where(x => !x.Deleted).AsQueryable();
            });
        }

        public async Task<IQueryable<Departamento>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Departamentos.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfHasPuestos(int departamentoId)
        {
            return await Task.Run(() => {
                return _context.Puestos.Any(x => !x.Deleted && x.DepartamentoId == departamentoId);
            });
        }
        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Departamentos.Any(x => !x.Deleted && x.Nombre.ToLower().Trim() == name.ToLower().Trim());
            });
        }
    }
}
