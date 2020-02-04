using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class IdiomaService : BaseRepository<Idioma>
    {
        public async Task<IQueryable<Idioma>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Idiomas.Where(x => !x.Deleted).AsQueryable();
            });
        }
        public async Task<IQueryable<Idioma>> GetActiveLanguages()
        {
            return await Task.Run(() => {
                return _context.Idiomas.Where(x => !x.Deleted && x.Estado == Models.Codes.Estado.Activo).AsQueryable();
            });
        }

        public async Task<IQueryable<Idioma>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Idiomas.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }

        public async Task<bool> ValidateIfExist(string name)
        {
            return await Task.Run(() => {
                return _context.Idiomas.Any(x => !x.Deleted && x.Nombre.ToLower().Trim() == name.ToLower().Trim());
            });
        }
    }
}
