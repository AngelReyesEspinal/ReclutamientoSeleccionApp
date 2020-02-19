using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Dtos;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class CandidatoService : BaseRepository<Candidato>
    {
        public async Task<IQueryable<Candidato>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Candidatos.Where(x => !x.Deleted).AsQueryable();
            });
        }
    }
}
