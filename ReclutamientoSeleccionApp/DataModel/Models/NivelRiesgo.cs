using System;
using System.Collections.Generic;
using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("NivelesDeRiesgo", Schema = "dbo")]
    public class NivelRiesgo : Base
    {
        public string Descripcion { get; set; }
    }
}
