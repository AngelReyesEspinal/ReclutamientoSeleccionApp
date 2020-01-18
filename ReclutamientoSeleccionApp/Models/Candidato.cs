using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class Candidato : Base
    {
        public Candidato()
        {
            Idiomas = new HashSet<Idioma>();
            Competencias = new HashSet<Competencia>();
            Capacitaciones = new HashSet<Capacitacion>();
            ExperienciasLaborales = new HashSet<ExperienciaLaboral>();
        }
        public string RecomendadoPor { get; set; }
        public string Experiencia { get; set; }
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public int IndentificacionPersonalId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual IndentificacionPersonal IndentificacionPersonal { get; set; }
        public virtual ICollection<Idioma> Idiomas { get; set; }
        public virtual ICollection<Competencia> Competencias { get; set; }
        public virtual ICollection<Capacitacion> Capacitaciones { get; set; }
        public virtual ICollection<ExperienciaLaboral> ExperienciasLaborales { get; set; }

    }
}
