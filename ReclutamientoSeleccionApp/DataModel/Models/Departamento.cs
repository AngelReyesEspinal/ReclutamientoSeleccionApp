using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Departamentos", Schema = "dbo")]
    public class Departamento : Base
    {
        public Departamento()
        {
            Puestos = new HashSet<Puesto>();
        }
        public string Nombre { get; set; }
        public virtual ICollection<Puesto> Puestos { get; set; }
    }
}

