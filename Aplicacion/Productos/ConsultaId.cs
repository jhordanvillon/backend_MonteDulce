using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class ConsultaId
    {
        public class ProductoUnico : IRequest<Producto> {
            public int Id {get;set;}
        }

        public class Handler : IRequestHandler<ProductoUnico, Producto>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Producto> Handle(ProductoUnico request, CancellationToken cancellationToken)
            {
                var producto = await _context.Producto.FindAsync(request.Id);
                return producto;
            }
        }
    }
}