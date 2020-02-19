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
    [Table("ExperienciasLaborales", Schema = "dbo")]
    public class ExperienciaLaboral : Base
    {
        public ExperienciaLaboral()
        {
            Candidatos = new HashSet<Candidato>();
        }
        public string PuestoOcupado { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int InstitucionId { get; set; }
        public int UserId { get; set; }
        public Institucion Institucion { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Candidato> Candidatos { get; set; }
        [NotMapped]
        private readonly InstitucionService institucionService = new InstitucionService();
        [NotMapped]
        public string NombreInstitucion
        {
            get
            {
                return Institucion != null
                    ? Institucion.NombreInstitucion
                    : institucionService.GetById(InstitucionId).NombreInstitucion;
            }
        }

    }
}
