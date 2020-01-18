using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.DataModel.Base
{
    public interface IBaseEntity : IBase
    {
        DateTime FechaDesde { get; set; }
        DateTime FechaHasta { get; set; }
    }
}
