using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.ErrorHandler;
using AutoMapper;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Boletas
{
    public class ConsultaId
    {
        public class BoletaUnica : IRequest<BoletaDto>{
            public Guid Id {get;set;}
        }
        public class Handler : IRequestHandler<BoletaUnica, BoletaDto>
        {
            private readonly TiendaContext _context;
            private readonly IMapper _mapper;
            public Handler(TiendaContext context,IMapper mapper){
                _context = context;
                _mapper = mapper;
            }
            public async Task<BoletaDto> Handle(BoletaUnica request, CancellationToken cancellationToken)
            {
                var boleta = await _context.Boleta
                .Include(x => x.ListaItems)
                .ThenInclude(y => y.Producto)
                .FirstOrDefaultAsync(x => x.BoletaId == request.Id);

                if(boleta == null){
                    throw new ExceptionHandler(HttpStatusCode.NotFound,new {curso = "No se encontro el curso que buscabas"});
                }
                var boletaDto = _mapper.Map<Boleta,BoletaDto>(boleta);
                return boletaDto;
            }
        }
    }
}