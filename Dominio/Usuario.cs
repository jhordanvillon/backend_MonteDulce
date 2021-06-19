using Microsoft.AspNetCore.Identity;

namespace Dominio
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto {get;set;}
        public string AdminNameRole {get;set;}
    }
}