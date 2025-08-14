using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.src.Modules.Usuarios.Domain.Entities;
using ColombianCoffeeApp.src.Modules.Usuarios.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories.Interfaces;

namespace ColombianCoffeeApp.src.Modules.Usuarios.Application
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepositorioUsuarios _repo;

        public UsuarioService(IRepositorioUsuarios repo)
        {
            _repo = repo;
        }

        public async Task<Usuario?> LoginAsync(string nombreUsuario, string contrasena)
        {
            return await _repo.ObtenerPorCredencialesAsync(nombreUsuario, contrasena);
        }

        public async Task RegistrarAdminAsync(string nombreUsuario, string contrasena)
        {
            var existente = await _repo.ObtenerPorNombreAsync(nombreUsuario);
            if (existente != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            var admin = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = RolUsuario.Administrador
            };

            await _repo.CrearAsync(admin);
        }

        public async Task CrearUsuarioAsync(string nombreUsuario, string contrasena, string rolTexto)
        {
            var existente = await _repo.ObtenerPorNombreAsync(nombreUsuario);
            if (existente != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            RolUsuario rol;
            if (!Enum.TryParse(rolTexto, true, out rol))
            {
                Console.WriteLine("⚠️ Rol inválido. Se asignará 'Usuario' por defecto.");
                rol = RolUsuario.Usuario;
            }

            var usuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = rol
            };

            await _repo.CrearAsync(usuario);
            Console.WriteLine("✅ Usuario creado correctamente.");
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _repo.ListarTodosAsync();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repo.EliminarAsync(id);
        }

        public async Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _repo.ObtenerPorNombreAsync(nombreUsuario);
        }
    }
}
