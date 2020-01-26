using ReclutamientoSeleccionApp.Models.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.DataModel.Base
{
    public interface IBase
    {
        int Id { get; set; }
        bool Deleted { get; set; }
    }
}
