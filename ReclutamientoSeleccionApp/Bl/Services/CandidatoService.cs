using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.DataModel.Dtos;
using ReclutamientoSeleccionApp.DataModel.Models;
using ReclutamientoSeleccionApp.Models;
using System;
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

        public List<Candidato> AdvanceSearch(SearchCandidatosModel model)
        {
            var candidatos = _context.Candidatos.Where(x => !x.Deleted).ToList();
            var result = candidatos.Where(x =>
                (model.Nombres == string.Empty
                || (model.Nombres.ToLower().Contains(x.Nombres.ToLower()) || model.Nombres.ToLower().Contains(x.Apellidos.ToLower())))
                && (model.Departamento == null || x.DepartamentoId == model.Departamento.Id)
                && (model.Puesto == null || x.PuestoId == model.Puesto.Id)
                && (model.Capacitacion == null || x.Capacitaciones.Any(y => y.Id == model.Capacitacion.Id))
                && (model.Competencia == null || x.Competencias.Any(y => y.Id == model.Competencia.Id))
                && (model.Idioma == null || x.Idiomas.Any(y => y.Id == model.Idioma.Id))
            ).ToList();
            return result;
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

        public string GetCedula(int Id)
        {
            var candidato = GetById(Id);
            return candidato.Cedula;
        }

        public ICollection<Idioma> GetIdiomas(int Id)
        {
            var candidato = GetById(Id);
            return candidato.Idiomas;
        }

        public ICollection<Competencia> GetCompetencias(int Id)
        {
            var candidato = GetById(Id);
            return candidato.Competencias;
        }

        public ICollection<Capacitacion> GetCapacitaciones(int Id)
        {
            var candidato = GetById(Id);
            return candidato.Capacitaciones;
        }

        public ICollection<ExperienciaLaboral> GetExperiencias(int Id)
        {
            var candidato = GetById(Id);
            return candidato.ExperienciasLaborales;
        }

        public bool ValidarCedula(string cedula)
        {
            var cedulaParts = new string[3];
            var municipio = string.Empty;
            var digitoVerificador = string.Empty;

            if (cedula.Length < 11)
            {
                return false;
            }
            else
            {
                cedulaParts[0] = cedula.Substring(0, 3);
                cedulaParts[1] = cedula.Substring(3, 7);
                cedulaParts[2] = cedula.Substring(10, 1);

                municipio = cedulaParts[0] + cedulaParts[1];
                digitoVerificador = cedulaParts[2];

                try
                {
                    Convert.ToInt32(digitoVerificador);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            var suma = 0;

            for (int i = 0; i < municipio.Length; i++)
            {
                var mod = "";

                if ((i % 2) == 0)
                    mod = "1";
                else
                    mod = "2";

                var val = string.Empty;

                try
                {
                    var a = municipio.Substring(i, 1);
                    Convert.ToInt32(a);
                    val = a;
                }
                catch (Exception)
                {
                    return false;
                }

                var res = Convert.ToInt32(Convert.ToInt32(val) * Convert.ToInt32(mod));

                if (res > 9)
                {
                    var res1 = res.ToString();
                    var uno = res1.Substring(0, 1);
                    var dos = res1.Substring(1, 1);
                    res = Convert.ToInt32(uno) + Convert.ToInt32(dos);
                }

                suma += res;
            }

            var elNumero = (10 - (suma % 10) % 10);

            if (elNumero == Convert.ToInt32(digitoVerificador) && cedulaParts[0] != "000")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
