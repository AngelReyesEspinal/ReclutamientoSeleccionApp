using ReclutamientoSeleccionApp.Core.Repository;
using ReclutamientoSeleccionApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReclutamientoSeleccionApp.Bl.Services.UserService
{
    public class UserService : BaseRepository<User>
    {
        public Task<User> Autenticar(string user, string passowrd)
        {
            return Task.Run(() => {
                return _context.Usuarios.FirstOrDefault(x => x.UserName == user && x.Password == passowrd);
            });
        }
    }
}
