using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class ConsultaId
    {
        public class CategoriaUnica : IRequest<Categoria>{
            public Guid Id {get;set;}
        }

        public class Handler : IRequestHandler<CategoriaUnica, Categoria>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Categoria> Handle(CategoriaUnica request, CancellationToken cancellationToken)
            {
                var categoria = await _context.Categoria.FindAsync(request.Id);
                return categoria;
            }
        }
    }
}