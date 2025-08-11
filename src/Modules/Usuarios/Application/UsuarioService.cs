using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Application
{
    public class UsuarioService
    {
        private readonly RepositorioUsuarios _repo;

        public UsuarioService(RepositorioUsuarios repo)
        {
            _repo = repo;
        }

        public Usuario? Login(string nombreUsuario, string contrasena)
        {
            return _repo.ObtenerPorCredenciales(nombreUsuario, contrasena);
        }

        public void RegistrarAdmin(string nombreUsuario, string contrasena)
        {
            var admin = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = "admin"
            };
            _repo.Crear(admin);
        }
    }
}