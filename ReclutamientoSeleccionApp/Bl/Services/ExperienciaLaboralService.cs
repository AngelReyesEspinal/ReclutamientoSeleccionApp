using ReclutamientoSeleccionApp.Core.DataModel.CurrentUser;
using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class ExperienciaLaboralService : BaseRepository<ExperienciaLaboral>
    {
        public async Task<IQueryable<ExperienciaLaboral>> GetAll()
        {
            return await Task.Run(() => {
                return _context.ExperienciasLaborales.Where(x => !x.Deleted && x.UserId == CurrentUser.Id).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfExist(string name, int institucionId)
        {
            return await Task.Run(() => {
                return _context.ExperienciasLaborales.Any(x => !x.Deleted && 
                        x.PuestoOcupado.ToLower().Trim() == name.ToLower().Trim()
                     && x.InstitucionId == institucionId);
            });
        }
        public async Task<IQueryable<ExperienciaLaboral>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.ExperienciasLaborales.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }
    }
}
