﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services
{
    public interface IAutenticacionService
    {
        bool Autenticar(string user, string passowrd);
    }
}
