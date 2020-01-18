﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.DataModel.Base
{
    public class BaseEntity : Base, IBaseEntity 
    { 
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}
