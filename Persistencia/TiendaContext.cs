using Dominio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class TiendaContext : IdentityDbContext<Usuario>
    {
        public TiendaContext(DbContextOptions options) : base(options) { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria>();
        }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<ItemBoleta> ItemBoleta {get;set;}
        public DbSet<Pedido> Pedido {get;set;}
        public DbSet<Boleta> Boleta {get;set;}
    }
}