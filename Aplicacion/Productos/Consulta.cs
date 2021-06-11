using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Productos
{
    public class Consulta
    {
        public class ListProductos : IRequest<List<Producto>>{}
        public class Handler : IRequestHandler<ListProductos, List<Producto>>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }

            public async Task<List<Producto>> Handle(ListProductos request, CancellationToken cancellationToken)
            {
                var productos = await _context.Producto.ToListAsync();
                return productos;
            }
        }
    }
}