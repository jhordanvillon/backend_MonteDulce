using System.Linq;
using System.Threading.Tasks;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
         public static async Task InsertarData(TiendaContext context, UserManager<Usuario> usuarioManager){
            if(!usuarioManager.Users.Any()){
                var usuario = new Usuario{NombreCompleto = "Jhordan",UserName = "Jhordan12",Email="jhordan@gmail.com"};
                await usuarioManager.CreateAsync(usuario,"Doremifa1$");
            }
            
        }
    }
}