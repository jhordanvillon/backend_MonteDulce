using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Categorias
{
    public class Consulta
    {
        public class ListaCategoria : IRequest<List<CategoriaDto>>{} //voy a recibir

        public class Handler : IRequestHandler<ListaCategoria, List<CategoriaDto>>
        {
            private readonly TiendaContext _context;
            private readonly IMapper _mapper;
            public Handler(TiendaContext context,IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoriaDto>> Handle(ListaCategoria request, CancellationToken cancellationToken)
            {
                var categorias = await _context.Categoria
                .Include(x => x.ProductoLista)
                .ToListAsync();
                var categoriaDto = _mapper.Map<List<Categoria>,List<CategoriaDto>>(categorias);
                return categoriaDto;
            }
        }
    }
}