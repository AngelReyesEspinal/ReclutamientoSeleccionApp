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
    [Table("Usuarios", Schema = "dbo")]
    public class User : Base
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
