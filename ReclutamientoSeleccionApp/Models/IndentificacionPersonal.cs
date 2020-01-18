using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class IndentificacionPersonal : Base
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
    }
}
