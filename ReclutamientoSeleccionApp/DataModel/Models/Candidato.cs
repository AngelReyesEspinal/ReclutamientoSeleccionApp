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
        public string Experiencia { get; set; }
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

    }
}
