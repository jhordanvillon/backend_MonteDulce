using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using MediatR;
using Persistencia;

namespace Aplicacion.Productos
{
    public class Eliminar
    {
        public class Ejecuta : IRequest {
            public int Id {get;set;}
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var producto = await _context.Producto.FindAsync(request.Id);
                if(producto == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound,new {producto = "No se encontro el producto"});
                }
                _context.Remove(producto);

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar los cambios");
            }
        }
    }
}