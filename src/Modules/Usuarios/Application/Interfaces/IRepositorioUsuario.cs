using System.Collections.Generic;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories.Interfaces
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena);
        Task CrearAsync(Usuario usuario);
        Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario);
        Task<List<Usuario>> ListarTodosAsync();
        Task<bool> EliminarAsync(int id);
    }
}
