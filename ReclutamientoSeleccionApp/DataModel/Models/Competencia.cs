using ReclutamientoSeleccionApp.Core.DataModel.Base;
using ReclutamientoSeleccionApp.Models.Codes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Competencias", Schema = "dbo")]
    public class Competencia : Base
    {
        public Competencia()
        {
            Candidatos = new HashSet<Candidato>();
        }
        public string Descripcion { get; set; }
        public Estado Estado { get; set; }
        public int PuestoId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
    }
}
