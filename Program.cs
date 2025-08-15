using ColombianCoffeeApp.src.Modules.Usuarios.Application;
using ColombianCoffeeApp.src.Modules.Usuarios.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Modules.Variedades.UI;
using ColombianCoffeeApp.src.Modules.Usuarios.UI;
using ColombianCoffeeApp.src.Shared.Context;
using Shared.Helpers;
using BorradoColombianCoffee.src.Modules.Usuarios.Domain;
using ColombianCoffeeApp.Services;
using System.Linq;
using ColombianCoffeeApp;
using Borrador2.src.UI;


internal class Program
{
    private static async Task Main(string[] args)
    {
        using var db = DbContextFactory.Create();
        DataSeeder.Seed(db);

        var usuarioRepo = new RepositorioUsuarios(db);
        var usuarioService = new UsuarioService(usuarioRepo);

        var menuPrincipal = new MenuPrincipal(usuarioService);
        await menuPrincipal.MostrarAsync();
    }
}
