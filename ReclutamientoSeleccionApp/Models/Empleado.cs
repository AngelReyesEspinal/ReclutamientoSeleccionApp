using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    public class Empleado : BaseEntity
    {
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public int IndentificacionPersonalId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual IndentificacionPersonal IndentificacionPersonal { get; set; }

    }
}
