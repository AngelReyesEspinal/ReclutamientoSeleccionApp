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
        public async Task<Candidato> AssociateAndSave(Candidato candidatoDto)
        {
            return await Task.Run(async () => {

                if (candidatoDto.Id > 0) {
                    var candidatoDb = GetById(candidatoDto.Id);
                    await DeleteAsync(candidatoDb);
                    candidatoDto.Id = 0;
                }

                var idiomasIds = candidatoDto.Idiomas.Select(x => x.Id).ToList();
                var competenciasIds = candidatoDto.Competencias.Select(x => x.Id).ToList();
                var capacitacionesIds = candidatoDto.Capacitaciones.Select(x => x.Id).ToList();
                var experienciasLaboralesIds = candidatoDto.ExperienciasLaborales.Select(x => x.Id).ToList();

                candidatoDto.Idiomas = _context.Idiomas.Where(x => idiomasIds.Contains(x.Id)).ToList();
                candidatoDto.Competencias = _context.Competencias.Where(x => competenciasIds.Contains(x.Id)).ToList();
                candidatoDto.Capacitaciones = _context.Capacitaciones.Where(x => capacitacionesIds.Contains(x.Id)).ToList();
                candidatoDto.ExperienciasLaborales = _context.ExperienciasLaborales.Where(x => experienciasLaboralesIds.Contains(x.Id)).ToList();

                await AddOrUpdateAsync(candidatoDto);
                return candidatoDto;
            });
        }

        public async Task<Candidato> GetCandidatoByUserId(int userId)
        {
            return await Task.Run(() => {
                return _context.Candidatos.FirstOrDefault(x => !x.Deleted && x.UserId == userId);
            });
        }

        public async Task<IQueryable<Candidato>> GetAll()
        {
            return await Task.Run(() => {
                return _context.Candidatos.Where(x => !x.Deleted).AsQueryable();
            });
        }

        public string GetFullName(int Id)
        {
            var candidato = GetById(Id);
            return candidato.Nombres + " " + candidato.Apellidos;
        }
    }
}
