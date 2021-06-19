using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Pedidos
{
    public class  Nuevo
    {
        public class Ejecuta : IRequest{
            public Guid BoletaId {get;set;}
            public string CodigoPago {get;set;}
            public string TipoPedido {get;set;}
        }
        public class Handler : IRequestHandler<Ejecuta>
        {
            private readonly TiendaContext _context;
            public Handler(TiendaContext context){
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var pedido = new Pedido{
                    PedidoId = Guid.NewGuid(),
                    BoletaId = request.BoletaId,
                    TipoPedido = request.TipoPedido,
                    CodigoPago = request.CodigoPago,
                    FechaCreacion = DateTime.UtcNow
                };

                var valor = await _context.SaveChangesAsync();//Devolver un estado de la transaccion 0 = no se hizo transacciones
                if(valor > 0){
                    return Unit.Value;
                }

                throw new Exception("No se pudo crear el pedido");
            }
        }
    }
}