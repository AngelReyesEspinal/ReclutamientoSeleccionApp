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
        [Description("Administrador")]
        ADMIN = 1,
        [Description("Estandar")]
        ESTANDAR = 2
    }
}
