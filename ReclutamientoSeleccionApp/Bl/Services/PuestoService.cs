using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Dtos;
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

        public async Task<List<PuestoDto>> GetAllDtos()
        {
            return await Task.Run(() => {
                List<PuestoDto> PuestosDto = new List<PuestoDto>();
                foreach (var puesto in _context.Puestos.Where(x => !x.Deleted).ToList()) {
                    var Dto = new PuestoDto();
                    PuestosDto.Add(Dto.MapFrom(puesto));
                }
                return PuestosDto;
            });
        }
        public async Task<IQueryable<Puesto>> GetActiveRecordsByDepartamento(int Departamento)
        {
            return await Task.Run(() => {
                return _context.Puestos.Where(x => !x.Deleted && (x.Estado == Models.Codes.Estado.Activo && x.DepartamentoId == Departamento)).AsQueryable();
            });
        }

        public async Task<bool> ValidateIfExist(string name, int deptId)
        {
            return await Task.Run(() => {
                return _context.Puestos.Any(x => !x.Deleted && (x.Nombre.ToLower().Trim() == name.ToLower().Trim() && x.DepartamentoId == deptId));
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
