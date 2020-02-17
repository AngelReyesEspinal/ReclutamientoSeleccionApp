using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Core.DataModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models
{
    [Table("Capacitaciones", Schema = "dbo")]
    public class Capacitacion : Base
    {
        public Capacitacion()
        {
            Candidatos = new HashSet<Candidato>();
        }
        public string Descripcion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int NivelId { get; set; }
        public int InstitucionId { get; set; }
        public int PuestoId { get; set; }
        public virtual Nivel Nivel { get; set; }
        public virtual Institucion Institucion { get; set; }
        public virtual Puesto Puesto { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
        [NotMapped]
        private readonly PuestoService puestoService = new PuestoService();
        [NotMapped]
        private readonly NivelService nivelService = new NivelService();
        [NotMapped]
        private readonly InstitucionService institucionService = new InstitucionService();
        [NotMapped]
        public string NombreNivel { get {
                return Nivel != null 
                    ? Nivel.Titulo 
                    : nivelService.GetById(NivelId).Titulo;
            } 
        }
        [NotMapped]
        public string NombreInstitucion { get {
                return Institucion != null 
                    ? Institucion.NombreInstitucion 
                    : institucionService.GetById(InstitucionId).NombreInstitucion;
            } 
        }
        [NotMapped]
        public string NombrePuesto { get {
                return Puesto != null 
                    ? Puesto.Nombre 
                    : puestoService.GetById(PuestoId).Nombre;
            } 
        }
    }
}

