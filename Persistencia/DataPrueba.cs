using Dominio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    class DataPrueba
    {
        public static async Task InsertarData(TiendaContext context, UserManager<Usuario> usuarioManager) {

            if (!usuarioManager.Users.Any()) {

                var usuario = new Usuario { NombreCompleto = "Kevin Astoyauri", UserName = "xXKevinRaxX", Email = "kevin@gmail.com" }; //usuario
                await usuarioManager.CreateAsync(usuario, "Doremifa1$"); //la contraseña debe ser alfanumerica y tener 1 signo

            }
        }
    }
}
