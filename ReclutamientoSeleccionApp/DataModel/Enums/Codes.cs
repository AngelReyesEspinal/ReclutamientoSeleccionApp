using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Models.Codes
{
    public enum Rol
    {
        Administrador = 1,
        Estandar = 2
    }

    public enum NivelDeRiesgo
    {
        Alto = 1,
        Medio = 2,
        Bajo = 3,
    }

    public enum Estado
    {
        Activo = 0,
        Inactivo = 1
    }
}
