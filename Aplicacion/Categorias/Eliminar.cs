using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using MediatR;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class Eliminar
    {
        public class Ejecuta : IRequest {
            public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var categoria = await _context.Categoria.FindAsync(request.Id);
                if(categoria == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound,new {categoria = "No se encontro el producto"});
                }
                _context.Remove(categoria);

                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar los cambios");
            }

        }
    }
}