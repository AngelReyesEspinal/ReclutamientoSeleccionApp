using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.Base;
using ReclutamientoSeleccionApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.DataModel.Models
{
    public class SolicitudPendiente : Base
    {
        public int CandidatoId { get; set; }
        public bool FueAceptado { get; set; }
        public bool EstaPendiente { get; set; }
        public virtual Candidato Candidato { get; set; }
        
    }
}
