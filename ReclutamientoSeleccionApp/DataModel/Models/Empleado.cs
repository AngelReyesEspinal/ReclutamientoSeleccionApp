using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Empleados", Schema = "dbo")]
    public class Empleado : Base
    {
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int CandidatoId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Candidato Candidato { get; set; }
        [NotMapped]
        private readonly CandidatoService _candidatoService = new CandidatoService();
        [NotMapped]
        public string Cedula
        {
            get
            {
                var fullName = Candidato != null
                     ? Candidato.Cedula 
                     : _candidatoService.GetCedula(CandidatoId);
                return fullName;
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                var fullName = Candidato != null 
                    ? Candidato.Nombres + " " + Candidato.Apellidos 
                    : _candidatoService.GetFullName(CandidatoId);
                return fullName;
            }
        }
        [NotMapped]
        public string NombrePuesto
        {
            get
            {
                return Puesto.Nombre;
            }
        }
        [NotMapped]
        public string NombreInstitucion
        {
            get
            {
                return Departamento.Nombre;
            }
        }
        [NotMapped]
        public string TodosLosIdiomas
        {
            get
            {
                string _idiomas = "";
                var idiomas = Candidato != null
                    ? Candidato.Idiomas
                    : _candidatoService.GetIdiomas(CandidatoId);
                foreach (var idioma in idiomas)
                {
                    _idiomas += idioma.Nombre + ", ";
                }
                return _idiomas;
            }
        }
        [NotMapped]
        public string TodasLasCompetencias
        {
            get
            {
                string _idiomas = "";
                var idiomas = Candidato != null
                    ? Candidato.Competencias
                    : _candidatoService.GetCompetencias(CandidatoId);

                foreach (var competencia in idiomas)
                {
                    _idiomas += competencia.Descripcion + ", ";
                }
                return _idiomas;
            }
        }
        [NotMapped]
        public string TodasLasCapacitaciones
        {
            get
            {
                string _idiomas = "";
                var idiomas = Candidato != null
                   ? Candidato.Capacitaciones
                   : _candidatoService.GetCapacitaciones(CandidatoId);
                foreach (var competencia in idiomas)
                {
                    _idiomas += competencia.Descripcion + ", ";
                }
                return _idiomas;
            }
        }
        [NotMapped]
        public string TodasLasExperiencias
        {
            get
            {
                string _idiomas = "";
                var idiomas = Candidato != null
                   ? Candidato.ExperienciasLaborales
                   : _candidatoService.GetExperiencias(CandidatoId);
                foreach (var competencia in idiomas)
                {
                    _idiomas += competencia.PuestoOcupado + ", ";
                }
                return _idiomas;
            }
        }
    }
}
