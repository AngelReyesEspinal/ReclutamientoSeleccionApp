using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Empleados", Schema = "dbo")]
    public class Empleado : Base
    {
        public decimal Salario { get; set; }
        public int PuestoId { get; set; }
        public int DepartamentoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int DatoPersonalId { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual DatoPersonal DatoPersonal { get; set; }
    }
}
