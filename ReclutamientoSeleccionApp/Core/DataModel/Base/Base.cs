using ReclutamientoSeleccionApp.Models.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.DataModel.Base
{
    public class Base : IBase
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
    }
}
