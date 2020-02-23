using ReclutamientoSeleccionApp.Models.Codes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Core.DataModel.CurrentUser
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Nombre { get; set; }
        public static string Apellido { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static Rol Rol { get; set; }
        public static DateTime FechaCreacion { get; set; }

        public static void SetCurrentUser(Models.User usuario)
        {
            Nombre = usuario.Nombre;
            Password = usuario.Password;
            Apellido = usuario.Apellido;
            UserName = usuario.UserName;
            Rol = usuario.Rol;
            FechaCreacion = usuario.FechaCreacion;
            Id = usuario.Id;
        }

    }
    public static class CandidatoSelected
    {
        public static int Id { get; set; }
    }
}
