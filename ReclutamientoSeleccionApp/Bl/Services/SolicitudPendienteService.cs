using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Models;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class SolicitudPendienteService : BaseRepository<SolicitudPendiente>
    {
        public IQueryable<SolicitudPendiente> GetAll()
        {
             return _context.SolicitudesPendientes.Where(x => !x.Deleted && x.EstaPendiente).AsQueryable();
        }

        public bool RechazarSolicitudes(List<int> candidatosId)
        {
            var solicitudes = _context.SolicitudesPendientes.Where(x => candidatosId.Contains(x.CandidatoId)).ToList();
            foreach (var solicitud in solicitudes)
            {
                solicitud.FueAceptado = false;
                solicitud.EstaPendiente = false;
                AddOrUpdate(solicitud);
            }
            return true;
        }

        public bool AprobarSolicitudes(int candidatoId)
        {
            var solicitud = _context.SolicitudesPendientes.FirstOrDefault(x => candidatoId == x.CandidatoId);
            solicitud.FueAceptado = true;
            solicitud.EstaPendiente = false;
            AddOrUpdate(solicitud);
            return true;
        }

        public async Task<SolicitudPendiente> GetByCandidatoId(int id)
        {
            return await Task.Run(() => {
                return _context.SolicitudesPendientes.FirstOrDefault(x => !x.Deleted && x.CandidatoId == id);
            });
        }
        
    }
}
