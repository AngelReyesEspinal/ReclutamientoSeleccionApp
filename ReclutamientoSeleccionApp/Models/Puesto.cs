using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class Puesto : Base
    {
        public string Nombre { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public int NivelRiesgoId { get; set; }
        public virtual NivelRiesgo NivelRiesgo { get; set; }

    }
}
