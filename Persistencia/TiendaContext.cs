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
            modelBuilder.Entity<Boleta>();
        }

        public DbSet<Boleta> Boleta { get; set; }
        public DbSet<Boleta> Categoria { get; set; }
        public DbSet<Boleta> ItemBoleta { get; set; }
        public DbSet<Boleta> Pedido { get; set; }
        public DbSet<Boleta> Producto { get; set; }
        public DbSet<Boleta> Usuario { get; set; }

    }
}