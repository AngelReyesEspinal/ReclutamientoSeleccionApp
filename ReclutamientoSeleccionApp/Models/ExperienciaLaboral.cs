using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class ExperienciaLaboral : BaseEntity
    {
        public string Empresa { get; set; }
        public string PuestoOcupado { get; set; }
        public decimal Salario { get; set; }
    }
}
