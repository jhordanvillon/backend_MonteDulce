using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class TiendaContext:IdentityDbContext<Usuario>
    {
        
    }
}