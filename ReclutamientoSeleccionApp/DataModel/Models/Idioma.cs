using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Idiomas", Schema = "dbo")]
    public class Idioma : Base
    {
        public string Nombre { get; set; }
    }
}
