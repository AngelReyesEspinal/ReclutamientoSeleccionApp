using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Capacitaciones", Schema = "dbo")]
    public class Capacitacion : Base
    {
        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int NivelId { get; set; }
        public int InstitucionId { get; set; }
        public virtual Nivel Nivel { get; set; }
        public virtual Institucion Institucion { get; set; }
    }
}

