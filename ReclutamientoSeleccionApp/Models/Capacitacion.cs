using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class Capacitacion : BaseEntity
    {
        public string Descripcion { get; set; }
        public int NivelId { get; set; }
        public int InstitucionId { get; set; }
        public virtual Nivel Nivel { get; set; }
        public virtual Institucion Institucion { get; set; }
    }
}

