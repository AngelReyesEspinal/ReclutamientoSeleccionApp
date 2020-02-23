using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Models;
using ReclutamientoSeleccionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class EmpleadoService : BaseRepository<Empleado>
    {
        private readonly SolicitudPendienteService _solicitudPendienteService;
        public EmpleadoService()
        {
            _solicitudPendienteService = new SolicitudPendienteService();
        }
        public IQueryable<Empleado> GetAll()
        {
            return _context.Empleados.Where(x => !x.Deleted).AsQueryable();
        }

        public bool VolverCandidatosAEmpleados(List<Candidato> candidatos)
        {
            foreach (var candidato in candidatos)
            {
                var empleado = new Empleado
                {
                    CandidatoId = candidato.Id,
                    PuestoId = candidato.PuestoId,
                    DepartamentoId = candidato.DepartamentoId,
                    FechaIngreso = DateTime.Now,
                    Salario = candidato.Salario > candidato.Puesto.SalarioMaximo ? candidato.Puesto.SalarioMaximo : candidato.Salario
                };
                AddOrUpdate(empleado);
                _solicitudPendienteService.AprobarSolicitudes(candidato.Id);
            }
            return true;
        }

        public async Task<Empleado> GetByCandidatoId(int id)
        {
            return await Task.Run(() => {
                return _context.Empleados.FirstOrDefault(x => !x.Deleted && x.CandidatoId == id);
            });
        }
    }
}
