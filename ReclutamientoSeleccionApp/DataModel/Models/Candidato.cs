using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Candidatos", Schema = "dbo")]
    public class Candidato : Base
    {
        public Candidato()
        {
            Idiomas = new HashSet<Idioma>();
            Competencias = new HashSet<Competencia>();
            Capacitaciones = new HashSet<Capacitacion>();
            ExperienciasLaborales = new HashSet<ExperienciaLaboral>();
        }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string RecomendadoPor { get; set; }
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual ICollection<Idioma> Idiomas { get; set; }
        public virtual ICollection<Competencia> Competencias { get; set; }
        public virtual ICollection<Capacitacion> Capacitaciones { get; set; }
        public virtual ICollection<ExperienciaLaboral> ExperienciasLaborales { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return Nombres + " " + Apellidos;
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
                foreach (var idioma in Idiomas)
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
                foreach (var competencia in Competencias)
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
                foreach (var competencia in Capacitaciones)
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
                foreach (var competencia in ExperienciasLaborales)
                {
                    _idiomas += competencia.PuestoOcupado + ", ";
                }
                return _idiomas;
            }
        }
    }
}
