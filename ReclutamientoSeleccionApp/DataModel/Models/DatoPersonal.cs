using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("DatosPersonales", Schema = "dbo")]
    public class DatoPersonal : Base
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
    }
}
