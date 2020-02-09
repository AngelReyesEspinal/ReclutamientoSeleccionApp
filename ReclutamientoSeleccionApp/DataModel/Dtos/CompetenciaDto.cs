using ReclutamientoSeleccionApp.Bl.Services.UserService;
using ReclutamientoSeleccionApp.Models;
using ReclutamientoSeleccionApp.Models.Codes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.DataModel.Dtos
{
    [NotMapped]
    public class CompetenciaDto
    {
        private readonly PuestoService puestoService = new PuestoService();
        public int Id { get; set; }
        public int PuestoId { get; set; }
        public string Descripcion { get; set; }
        public string PuestoNombre { get; set; }
        public Estado Estado { get; set; }
        public bool Deleted { get; set; }

        public CompetenciaDto MapFrom(Competencia competencia)
        {
            Id = competencia.Id;
            PuestoNombre = competencia.Puesto != null ? competencia.Puesto.Nombre : puestoService.GetById(competencia.PuestoId).Nombre;
            Estado = competencia.Estado;
            Descripcion = competencia.Descripcion;
            Deleted = competencia.Deleted;
            PuestoId = competencia.PuestoId;
            return this;
        }
    }
}
