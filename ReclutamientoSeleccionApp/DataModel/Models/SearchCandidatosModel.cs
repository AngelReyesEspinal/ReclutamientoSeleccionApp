using ReclutamientoSeleccionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.DataModel.Models
{
    public class SearchCandidatosModel
    {
        public string Nombres { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Competencia Competencia { get; set; }
        public virtual Capacitacion Capacitacion { get; set; }
        public virtual Idioma Idioma { get; set; }
    }
}
