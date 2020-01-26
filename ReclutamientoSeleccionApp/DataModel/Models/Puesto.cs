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
    [Table("Puestos", Schema = "dbo")]
    public class Puesto : Base
    {
        public string Nombre { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public Estado Estado { get; set; }
        public virtual NivelDeRiesgo NivelDeRiesgo { get; set; }
    }
}
