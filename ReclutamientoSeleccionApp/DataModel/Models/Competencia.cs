using ReclutamientoSeleccionApp.Core.DataModel.Base;
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
        public string Descripcion { get; set; }
        public int PuestoId { get; set; }
        public virtual Puesto Puesto { get; set; }
    }
}
