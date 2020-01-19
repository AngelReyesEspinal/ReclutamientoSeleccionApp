using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Niveles", Schema = "dbo")]
    public class Nivel : Base
    {
        public Nivel()
        {
            Capacitaciones = new HashSet<Capacitacion>();
        }
        public int Descripcion { get; set; }
        public virtual ICollection<Capacitacion> Capacitaciones { get; set; }
    }
}
