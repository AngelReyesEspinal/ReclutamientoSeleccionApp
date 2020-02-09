using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("ExperienciasLaborales", Schema = "dbo")]
    public class ExperienciaLaboral : Base
    {
        public ExperienciaLaboral()
        {
            Candidatos = new HashSet<Candidato>();
        }
        public string PuestoOcupado { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }

    }
}
