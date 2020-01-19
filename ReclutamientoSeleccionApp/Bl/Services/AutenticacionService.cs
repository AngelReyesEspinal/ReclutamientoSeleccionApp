using ReclutamientoSeleccionApp.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly Contexto _context;
        public AutenticacionService()
        {
            _context = new Contexto();
        }

        public bool Autenticar (string user, string passowrd) 
        {
            return _context.Usuarios.Any(x => x.UserName == user && x.Password == passowrd);
        }
    }
}
