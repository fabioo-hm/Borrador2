using System.Collections.Generic;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> LoginAsync(string nombreUsuario, string contrasena);
        Task RegistrarAdminAsync(string nombreUsuario, string contrasena);
        Task CrearUsuarioAsync(string nombreUsuario, string contrasena, string rolTexto);
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<bool> EliminarAsync(int id);
        Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario);
    }
}
