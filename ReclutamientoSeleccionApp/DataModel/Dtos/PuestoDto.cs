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
    public class PuestoDto 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public Estado Estado { get; set; }
        public NivelDeRiesgo NivelDeRiesgo { get; set; }
        public string DepartamentoNombre { get; set; }
        public bool Deleted { get; set; }

        public PuestoDto MapFrom(Puesto puesto) {
            Id = puesto.Id;
            Nombre = puesto.Nombre;
            SalarioMinimo = puesto.SalarioMinimo;
            SalarioMaximo = puesto.SalarioMaximo;
            Estado = puesto.Estado;
            NivelDeRiesgo = puesto.NivelDeRiesgo;
            DepartamentoNombre = puesto.Departamento.Nombre;
            Deleted = puesto.Deleted;
            return this;
        }
    }
}
