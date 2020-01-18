using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class Institucion : Base
    {
        public Institucion()
        {
            Capacitaciones = new HashSet<Capacitacion>();
        }
        public int Nombre { get; set; }
        public virtual ICollection<Capacitacion> Capacitaciones { get; set; }
    }
}
