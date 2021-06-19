using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Boletas
{
    public class Consulta
    {
        public class ListaBoleta : IRequest<List<BoletaDto>>{}
        public class Handler : IRequestHandler<ListaBoleta, List<BoletaDto>>
        {
            private readonly TiendaContext _context;
            private readonly IMapper _mapper;
            public Handler(TiendaContext context,IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BoletaDto>> Handle(ListaBoleta request, CancellationToken cancellationToken)
            {
                var boletas = await _context.Boleta
                .Include(x => x.ListaItems)
                .ThenInclude(y => y.Producto)
                .ToListAsync();

                var boletasDto = _mapper.Map<List<Boleta>,List<BoletaDto>>(boletas);
                return boletasDto;
            }
        }
    }
}