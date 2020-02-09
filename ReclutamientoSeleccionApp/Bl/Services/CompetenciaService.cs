using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Dtos;
using ReclutamientoSeleccionApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class CompetenciaService : BaseRepository<Competencia>
    {
        public async Task<IQueryable<Competencia>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Competencias.Where(x => !x.Deleted).AsQueryable();
            });
        }
        public async Task<bool> ValidateIfExist(string descripcion, int puestoId)
        {
            return await Task.Run(() => {
                return _context.Competencias.Any(x => !x.Deleted && (x.Descripcion.ToLower().Trim() == descripcion.ToLower().Trim() && x.PuestoId == puestoId));
            });
        }
        public async Task<List<CompetenciaDto>> GetAllDtos()
        {
            return await Task.Run(() => {
                List<CompetenciaDto> competenciaDto = new List<CompetenciaDto>();
                foreach (var competencia in _context.Competencias.Where(x => !x.Deleted).ToList())
                {
                    var Dto = new CompetenciaDto();
                    competenciaDto.Add(Dto.MapFrom(competencia));
                }
                return competenciaDto;
            });
        }
        public async Task<IQueryable<Competencia>> GetActiveByPuesto(int puestoId)
        {
            return await Task.Run(() => {
                return _context.Competencias.Where(x => !x.Deleted && x.Estado == Models.Codes.Estado.Activo && x.PuestoId == puestoId).AsQueryable();
            });
        }

        public async Task<IQueryable<Competencia>> GetAllByIds(List<int> ids)
        {
            return await Task.Run(() => {
                return _context.Competencias.Where(x => ids.Contains(x.Id)).AsQueryable();
            });
        }

        public async Task<bool> ValidateIfExist(string descripcion)
        {
            return await Task.Run(() => {
                return _context.Competencias.Any(x => !x.Deleted && x.Descripcion.ToLower().Trim() == descripcion.ToLower().Trim());
            });
        }
    }
}
