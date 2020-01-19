using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Empresas", Schema = "dbo")]
    public class Empresa : Base
    {
        public string Nombre { get; set; }
    }
}
